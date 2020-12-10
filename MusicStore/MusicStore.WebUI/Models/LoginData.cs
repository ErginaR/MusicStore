using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.WebUI.Models
{
    public class LoginData
    {
        [Required(ErrorMessage="Enter your name")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Enter your password")]
        public string Password { get; set; }
    }
}