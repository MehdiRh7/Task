using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Infrastructures.Senders
{
    public class SendEmail
    {
        public void Send(string to, string subject, string body)
        {
            // مشخص کردن اطلاعات ایمیل فرستنده
            string senderEmail = "mehdddddddi7@gmail.com";
            string senderPassword = "mehdi*rh77";

            // مشخص کردن اطلاعات ایمیل گیرنده
            string recipientEmail = to;

            // ایجاد شیء MailMessage
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(recipientEmail);
            mail.Subject = subject;
            mail.Body = body;

            // ایجاد شیء SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            try
            {
                // ارسال ایمیل
                smtpClient.Send(mail);
                Console.WriteLine("ایمیل با موفقیت ارسال شد.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطا در ارسال ایمیل: " + ex.Message);
            }

        }
    }
}
