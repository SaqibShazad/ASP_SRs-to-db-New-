using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace webweb.Models
{
    public class Contact
    {
        [Required]

        [Display(Name = "Name *")]

        public string Name { get; set; }

        [Required]

        [DataType(DataType.EmailAddress)]

        [Display(Name = "Email address *")]

        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]

        [Display(Name = "Phone Number")]

        public string Phone { get; set; }

        [Required]

        [Display(Name = "Message *")]

        public string Body { get; set; }

        public DateTime SentDate { get; set; }

        public string IP { get; set; }



        public string BuildMessage()
        {

            var message = new StringBuilder();

            message.AppendFormat("Date: {0:yyyy-MM-dd hh:mm}\n", SentDate);

            message.AppendFormat("Email from: {0}\n", Name);

            message.AppendFormat("Email: {0}\n", Email);

            message.AppendFormat("Phone: {0}\n", Phone);

            message.AppendFormat("IP: {0}\n", IP);

            message.AppendFormat("Message: {0}\n", Body);

            return message.ToString();

        }
    }
}
    

    
