using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;

namespace DD1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            SendByEmail("subject", "messageBody","");

            return new string[] { "value1", "value2" };
        }

        public void SendByEmail(string subject, string messageBody, string recipientsGroup)
        {
            string addresses = ConfigurationManager.AppSettings[recipientsGroup];

            string errStr = "";

            try
            {
                

                var msg = new MailMessage
                {
                    From = new MailAddress("chenvardi9@gmail.com", "Deposit Alert"),
                    Subject = subject,
                    Body = messageBody
                };

                //if (!string.IsNullOrWhiteSpace(addresses))
                //{
                //    string[] csvList = addresses.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                //    foreach (string address in csvList)
                //    {
                //        if (!string.IsNullOrWhiteSpace(addresses))
                //        {
                //            msg.To.Add(new MailAddress(address));
                //        }
                //    }

                msg.To.Add(new MailAddress("dandan53@gmail.com"));

                if (msg.To.Count > 0)
                {
                    var SMTP = new SmtpClient();
                    SMTP.EnableSsl = true;
                    SMTP.Send(msg);
                }
            }
                //}
            catch (Exception ex)
            {
                errStr = ex.ToString();

            }

            string ee = errStr + "";
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