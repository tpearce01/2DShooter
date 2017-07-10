using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

/*********************************************************************************
 * class MailManager
 * 
 * Function: Adapted from 
 *      answers.unity3d.com/questions/433283/how-to-send-email-with-c.html. 
 *      Create and send emails from "hiretylersimulator@gmail.com" to 
 *      "tpearce@uci.edu"
 *********************************************************************************/
public class MailManager : MonoBehaviour
{
    /// <summary>
    /// Test function for sending mail. Sends to tpearce@uci.edu
    /// </summary>
    void SendMailTest()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("hiretylersimulator@gmail.com");
        mail.To.Add("tpearce@uci.edu");
        mail.Subject = "Test Mail";
        mail.Body = "This is for testing SMTP mail from GMAIL";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("hiretylersimulator@gmail.com", "h1retyler") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");
    }

    /// <summary>
    /// Send 2 emails. One goes to tpearce@uci.edu containing interview information. The second is sent
    /// to the hiring manager to confirm the date and time of the interview.
    /// </summary>
    /// <param name="i"></param>
    void SendMail(Interview i)
    {
        MailMessage toSelf = new MailMessage();

        toSelf.From = new MailAddress("hiretylersimulator@gmail.com");
        toSelf.To.Add("tpearce@uci.edu");
        toSelf.Subject = "Interview for " + i.companyName + " on " + i.day + "/" + i.month;
        toSelf.Body = "Hello, Tyler.\n " + i.hiringManagerName + " would like you to come in for an interview" +
            " for the " + i.positionTitle + " position at " + i.companyName + " on " + i.day + "/" + i.month +
            "/" + i.year + " at " + i.hour + ":" + i.minute + ". Please call " + i.hiringManagerName + " at " + 
            i.phoneNumber + " to confirm your interview. Good luck!\n\nMessage: " + i.extraMessage + "\n\n" +
            i.hiringManagerName + "\n" + i.hiringManagerEmail;

        MailMessage toHiringManager = new MailMessage();
        toHiringManager.From = new MailAddress("hiretylersimulator@gmail.com");
        toHiringManager.To.Add(i.hiringManagerEmail);
        toHiringManager.Subject = "Interview for Tyler Pearce on " + i.day + "/" + i.month;
        toHiringManager.Body = "Dear " + i.hiringManagerName + ",\nThank you for setting up an interview with Tyler Pearce " +
            "for the " + i.positionTitle + " position on " + i.day + "/" + i.month + "/" + i.year + " at " + i.hour + ":" + 
            i.minute + ". He will give you a call in the next 24-48 hours to confirm the appointment. If you have any " + 
            "additional comments or concerns, feel free to email Tyler at tpearce@uci.edu or call at (949) 201 - 5315.\n\n";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("hiretylersimulator@gmail.com", "h1retyler") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(toSelf);
        smtpServer.Send(toHiringManager);
        Debug.Log("success");
    }
}
