using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapstoneToDo.Models
{
    public partial class ToDoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }


        public bool Complete { get; set; } = false;
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
