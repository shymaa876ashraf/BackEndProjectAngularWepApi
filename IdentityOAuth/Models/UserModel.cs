using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdentityOAuth.Models
{
    public class UserModel:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        public string confirmPassword { get; set; }
     

    }
}