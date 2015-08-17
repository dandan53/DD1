using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using DD1.Models;

namespace DD1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Contact> Get(string phone)
        {
            if (phone != null && phone.Equals("5382"))
            {
                return DAL.Instance.GetContacts();                
            }

            return null;

            //string retVal = SendByEmail("subject", "messageBody","");
            //return retVal; //new string[] { retVal };
        }

        public string SendByEmail(string subject, string messageBody, string recipientsGroup)
        {
            string addresses = ConfigurationManager.AppSettings[recipientsGroup];

            string retVal = "good";

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
                retVal = ex.ToString();

            }

            return retVal;
        }
    

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(Contact contact)
        {
            if (contact != null && contact.Name.Equals("0") && contact.Phone.Equals("5382"))
            {
                DAL.Instance.RemoveContacts();
            }
            else
            {
                DAL.Instance.AddContact(contact);
            }
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