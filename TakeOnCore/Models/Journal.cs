using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;


namespace TakeOnCore.Models
{
     public class Journal
     {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public String Description { get; set; }

        public virtual ApplicationUser Peer { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedTime { get; set; }

        public virtual List<DailyRoutine> DailyRoutines { get; set; }

        public bool IsActive { get; set; } = true;

        //private readonly IHttpContextAccessor _httpContextAccessor;



        public Journal()
        {
            CreatedTime = DateTime.Now;
        }
    }
}
