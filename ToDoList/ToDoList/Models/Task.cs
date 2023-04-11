using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class Task
    {

        public int TaskID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Task Made")]
        [DisplayFormat(DataFormatString ="{0:dd-MMM-yyy}", ApplyFormatInEditMode = false)]
        public DateTime TaskMade { get; set; }

        [Display(Name = "Due Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyy}", ApplyFormatInEditMode = false)]

        public DateTime DueDate { get; set; }

        [Display(Name = "Task Priority")]

        public string TaskPriority { get; set; }
        public bool Done { get; set; }

    }
}