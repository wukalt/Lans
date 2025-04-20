using System.ComponentModel.Design;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Hosting;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace Lans.Core.Senders;

public class EmailSender
{
    public static void Send(string to, string subject, string body)
    {
        MailMessage mail = new();
        SmtpClient smtp = new("smtp.gmail.com", 587);
        
        mail.From = new MailAddress("EMAIL", "لنس وب");
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true;

        smtp.Credentials = new NetworkCredential("EMAIL", "PASSWORD");
        smtp.EnableSsl = true;

        smtp.Send(mail);
    }
}
