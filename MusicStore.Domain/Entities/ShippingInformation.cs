using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class ShippingInformation
    {
        [Required(ErrorMessage="Enter your first name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name:")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter your adress:")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Enter a city name:")]
        public string City { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Enter your postal code:")] 
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Enter your email:")]
        public string Email { get; set; }
        public string PromoCode { get; set; }
    }
}
