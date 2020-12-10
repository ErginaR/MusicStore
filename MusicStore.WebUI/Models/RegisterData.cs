using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.WebUI.Models
{
    public class RegisterData
    {
        public User User { get; set; }
        public string PasswordConfirm { get; set; }
    }
}