using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakeOnCore.Models
{
    public class Goal
    {
        public Goal()
        {
            this.CreationDate = DateTime.Now;
        }

        public int Id { get; set; }

        public virtual Journal Journal { get; set; }

        public virtual ApplicationUser User { get; set; }

        public String Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get;  set; }

        public virtual List<Post> Posts { get;  set; }

        public GoalType GoalType { get; set; }

    }
}
