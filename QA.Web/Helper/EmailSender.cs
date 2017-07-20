using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace QA.Web.Helper
{
    public class EmailSender
    {
        public static void SendEmail(string to, string Subject, string Body)
        {
            var fromAddress = new MailAddress("qats.noreply@gmail.com", "Qats-email");
            var toAddress = new MailAddress(to);
            const string fromPassword = "$QATS2016!";
            string subject = Subject;
            string body = Body;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }

        }
    }
}