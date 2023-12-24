using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75.Models
{
    public class VCard
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }


        public string ToVCard()
        {
            return
                "BEGIN:VCARD" + 
                $"FN:{Firstname} {Surname}" + Environment.NewLine +
                $"N:{Surname};{Firstname};;;" + Environment.NewLine +
                $"TEL:{Phone}" + Environment.NewLine +
                $"EMAIL:{Email} " + Environment.NewLine +
                $"ADR:;;{City};;{Country};;" + Environment.NewLine +
                "END:VCARD";
        }
    }


}
