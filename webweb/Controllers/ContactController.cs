using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using webweb.Models;


namespace webweb.Controllers
{
    public class ContactController : Controller
    {

        public ActionResult Index()
        {

            ViewBag.Success = false;

            return View(new Contact());

        }

        [HttpPost]

        public ActionResult Index(Contact contact)
        {

            ViewBag.Success = false;

            {
                try
                {

                    if (ModelState.IsValid)
                    {

                        // Collect additional data;

                        contact.SentDate = DateTime.Now;

                        contact.IP = Request.UserHostAddress;

                        string from_mail = "uniquepearl01@gmail.com";
                        string from_pass = "lifemeinkabhikabhi";

                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.EnableSsl = true;
                        smtpClient.Host = "smtp.gmail.com";
                        smtpClient.Port = 587;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(from_mail, from_pass);


                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("uniquepearl01@gmail.com"); // From
                        mail.To.Add(new MailAddress("uniquepearl01@gmail.com")); // To

                        mail.Subject = "Your email subject"; // Subject
                        mail.Body = contact.BuildMessage();

                        ViewBag.Success = true;
                        smtpClient.Send(mail);
                    }

                }

                catch (Exception)
                {
                    Response.Write("Success");

                }
               
            }

            return View();
        }
    }
}
       
    
