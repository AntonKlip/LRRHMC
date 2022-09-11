using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using TMPro;

public class EmailFactory : MonoBehaviour
{
    public TMP_InputField bodyMessage;

    public void SendEmail()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        SmtpServer.Timeout = 10000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("Malvina.Haneke@gmail.com");
        mail.To.Add(new MailAddress(GameManager.instance.userEMail));

        mail.Subject = "Test Email through C Sharp App";
        mail.Body = bodyMessage.text;


        SmtpServer.Credentials = new System.Net.NetworkCredential("Malvina.Haneke@gmail.com", "LittleRedHoodMustCry") as ICredentialsByHost; SmtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        SmtpServer.Send(mail);
    }
}
