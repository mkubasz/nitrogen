using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TeamOfCode.Models;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;  
namespace TeamOfCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();


        //}
        [HttpGet]
        public ActionResult Kontakt()
        {
        
        return PartialView();
        }

        [HttpPost, ActionName("Kontakt")]
        public ActionResult Kontaktp(EmailFormModel emailForm)
        {
            try
            {
                ViewBag.Wyjatek = "Email wysłany poprawnie";
                string to = "marcin.mazurowski@o2.pl"; //To address    
                string from = "teamofcodex@gmail.com"; //From address    
                MailMessage message = new MailMessage(from, to);

                string mailbody = "Name: " + emailForm.FromName + " message:" + emailForm.Message;
                message.Subject = emailForm.FromEmail;
                message.Body = mailbody;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
//Gmail smtp    
                    System.Net.NetworkCredential basicCredential1 = new
                        System.Net.NetworkCredential("teamofcodex@gmail.com", "!23456789");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential1;
                    try
                    {
                        client.Send(message);
                        string wiadomosc ="Email wysłany poprawnie";
                        return RedirectToAction("Sent", new {message=wiadomosc});
                    }

                    catch (Exception ex)
                    {

                        //throw ex;
                        string wiadomosc = "Email niewysłany";
                        return RedirectToAction("Sent", new { message = wiadomosc });
                    }
                }
            }
            catch(Exception ex)
            {
                string wiadomosc = "Email niewysłany";
                return RedirectToAction("Sent", new { message = wiadomosc });
            }
        }
           











            //if (ModelState.IsValid)
            //{
            //    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            //    var message = new MailMessage();
            //    message.To.Add(new MailAddress("szarmancki@poczta.onet.pl"));  // replace with valid value 
            //    message.From = new MailAddress("szarmancki@poczta.onet.pl");  // replace with valid value
            //    message.Subject = emailForm.FromName;
            //    message.Body = string.Format(body, emailForm.FromName, emailForm.FromEmail, emailForm.Message);
            //    message.IsBodyHtml = true;

            //    using (var smtp = new SmtpClient())
            //    {
            //        var credential = new NetworkCredential
            //        {
            //            UserName = "szarmancki@poczta.onet.pl",  // replace with valid value
            //            Password = "mamm1985"  // replace with valid value
            //        };
            //        smtp.Credentials = credential;
            //        smtp.Host = "smtp.poczta.onet.pl";
            //        smtp.Port = 465;
            //        smtp.EnableSsl = true;
            //        smtp.SendMailAsync(message);
            //        return RedirectToAction("Sent");
            //    }
            //}
         
        

        public ActionResult Sent(string message)
        {
            return View("Sent",(object)message);
        }
    }
}