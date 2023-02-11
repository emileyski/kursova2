using System.Linq;
using System;
using System.Net;
using System.Net.Mail;
using RialtoLib.Model;
using System.IO;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RialtoLib.Service
{
    public static class GenericService
    {
        public static bool SendMessage(string receiver_fullname, string receiver_mail,
            string mail_subject, string mail_context, string sender = "Artem", Attachment attachment = null)
        {
            NetworkCredential cred = new NetworkCredential("artempechka24@gmail.com", "cqncyzcmkyeqkvjt");
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = cred
            };
            MailAddress fromMail = new MailAddress("artempechka24@gmail.com", sender);
            MailAddress toMail = new MailAddress(receiver_mail, receiver_fullname);

            MailMessage message = new MailMessage(fromMail, toMail)
            {
                Subject = mail_subject,
                Body = mail_context
            };

            if (attachment != null)
                message.Attachments.Add(attachment);

            try
            {
                smtp.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static async Task<Tuple<bool, object>> IsAuthorizated(RialtoEntities entities,
            LoginType loginType, string path)
        {
            try
            {
                if (File.Exists($"{path}\\userData.json"))
                {
                    var data = JsonConvert
                        .DeserializeObject<LoginInfo>(File.ReadAllText("userData.json"));
                    //var loginInfo = new LoginInfo();
                    //loginInfo.LastLogin = DateTime.Now;
                    switch (loginType)
                    {
                        case LoginType.Admin:
                            var admin = await entities.Companies
                                .FirstOrDefaultAsync(f => f.email == data.Email);
                            return new Tuple<bool, object>(admin != null, admin);
                        case LoginType.Driver:
                            var driver = await entities.Drivers
                                .FirstOrDefaultAsync(f => f.email == data.Email);
                            return new Tuple<bool, object>(driver != null, driver);
                        case LoginType.Customer:
                            var customer = await entities.Customers
                                .FirstOrDefaultAsync(f => f.email == data.Email);
                            return new Tuple<bool, object>(customer != null, customer);
                        default:
                            return new Tuple<bool, object>(false, null);
                    }
                }
                else
                    return new Tuple<bool, object>(false, null);
            }
            catch
            {
                return new Tuple<bool, object>(false, null);
            }
        }
        public static void SaveData(string email, string path)
        {
            var logData = new LoginInfo(email, DateTime.Now);
            File.WriteAllText($"{path}\\userData.json", JsonConvert.SerializeObject(logData));
        }
        public static void LogOut(string path)
        {
            try
            {
                File.Delete($"{path}\\userData.json");
            }
            catch { }
        }
    }
    public class LoginInfo
    {
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public LoginInfo(string email, DateTime lastLogin)
        {
            Email = email;
            LastLogin = lastLogin;
        }
        public LoginInfo() { }
    }
    public enum LoginType
    {
        Admin = 0,
        Customer = 1,
        Driver = 2
    }
}