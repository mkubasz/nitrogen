using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Repozytorium.Models;

namespace SphynxWeb.Controllers
{
    public class ContactController : Controller
    {
        /*public ActionResult Kontakt()
        {

            return PartialView();
        }*/

        [HttpPost, ActionName("Kontakt")]
        public ActionResult Kontaktp(ContactModel emailForm)
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
                        string wiadomosc = "Email wysłany poprawnie";
                        return RedirectToAction("Sent", new { message = wiadomosc });
                    }

                    catch (Exception ex)
                    {

                        //throw ex;
                        string wiadomosc = "Email niewysłany";
                        return RedirectToAction("Sent", new { message = wiadomosc });
                    }
                }
            }
            catch (Exception ex)
            {
                string wiadomosc = "Email niewysłany";
                return RedirectToAction("Sent", new { message = wiadomosc });
            }
        }

        public ActionResult Sent(string message)
        {
            return View("Sent", (object)message);
        }
    }
}