using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TakeOnCore.Models
{
    public class Post
    {
        public int Id { get;  set; }

        public virtual Journal Journal { get;  set; }

        public virtual ApplicationUser User { get;  set; }

        public String Content { get;  set; }

        public virtual DailyRoutine DailyRoutine { get;  set; }

        [DataType(DataType.Date)]
        public DateTime DestinateDate { get;  set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationTime { get;  set; }

        public virtual PostType PostType { get;  set; }


        public Post()
        {
            CreationTime = DateTime.Now;
        }
    }
}
