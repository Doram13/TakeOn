using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace TakeOnCore.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        override public string Id { get; set; }
        
        override public String UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        override public String Email { get; set; }
 
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationTime { get; set; }

        public virtual ApplicationUser Peer { get; set; }

        public ApplicationUser()
        {
            this.UserName = base.UserName;
            this.Email = base.Email;
            this.Password = base.PasswordHash;
            CreationTime = DateTime.Now;
        }
    }
}
