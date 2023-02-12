using GMap.NET;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;

namespace RialtoLib.Service
{
    public static class MapService
    {
        public static async Task<PointLatLng> GetLocationByAdress(string Adress)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://forward-reverse-geocoding.p.rapidapi.com/v1/search?q={Adress}&accept-language=en&polygon_threshold=0.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "9fc976c5bemshf7e9dacfab36645p14ef8ajsn49294716680d" },
        { "X-RapidAPI-Host", "forward-reverse-geocoding.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                dynamic dynamic = JsonConvert.DeserializeObject<dynamic>(body);

                double lat = (double)dynamic[0]["lat"];
                double lon = (double)dynamic[0]["lon"];

                return new PointLatLng(lat, lon);
            }
        }

        public static async Task<Tuple<float, GMapRoute>> GetRouteBeetwenTwoPoints(PointLatLng from, PointLatLng to)
        {
            //var route = GoogleMapProvider.Instance.GetRoute()
            var route_data = await GetRouteData(from, to);
            dynamic dynamic = JsonConvert.DeserializeObject<dynamic>(await GetRouteData(from, to));
            int pointCount = (dynamic["features"][0]["geometry"]["coordinates"][0].Count);

            List<PointLatLng> points = new List<PointLatLng>();
            for (int i = 0; i < pointCount; i++)
            {
                var x = (double)dynamic["features"][0]["geometry"]["coordinates"][0][i][1];
                var y = (double)dynamic["features"][0]["geometry"]["coordinates"][0][i][0];


                points.Add(new PointLatLng(x, y));
            }

            float distance = ((float)dynamic["features"][0]["properties"]["distance"]) / 1000;
            var route = new GMapRoute(points, "returnable_route") { Stroke = new System.Drawing.Pen(Color.Red, 5) };

            return new Tuple<float, GMapRoute>(distance, route);
        }

        public static async Task<string> GetRouteData(PointLatLng from, PointLatLng to)
        {
            string from_lat, from_lon, to_lat, to_lon;
            from_lat = from.Lat.ToString().Replace(',', '.');
            from_lon = from.Lng.ToString().Replace(',', '.');
            to_lat = to.Lat.ToString().Replace(',', '.');
            to_lon = to.Lng.ToString().Replace(',', '.');
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://route-and-directions.p.rapidapi.com/v1/routing?waypoints={from_lat}%2C{from_lon}%7C{to_lat}%2C{to_lon}&mode=drive"),
                Headers =
        {
            { "X-RapidAPI-Key", "9fc976c5bemshf7e9dacfab36645p14ef8ajsn49294716680d" },
            { "X-RapidAPI-Host", "route-and-directions.p.rapidapi.com" },
        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return body;
            }
        }
    }
}
