using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace DD1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            try
            {
                string fromEmail = "dandan53@gmail.com";
                MailMessage mailMessage = new MailMessage(fromEmail, "dandan53@gmail.com", "Subject", "Body");
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromEmail, "haim1234");
                
                smtpClient.Send(mailMessage);
                
                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //mail.From = new MailAddress("dandan53@gmail.com");
                //mail.To.Add("dandan53@gmail.com");
                //mail.Subject = "Test Mail";
                //mail.Body = "This is for testing SMTP mail from GMAIL";

                //SmtpServer.Port = 587;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("user", "pass");
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return new string[] { "error" };
            }
            
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}