using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace ADETQ2_PANCAKE.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter your Surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please Enter your Firstname")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please Enter your MI")]
        public string MI { get; set; }
        [Required(ErrorMessage = "Please Enter your Student_Number")]
        public string Student_Number { get; set; }
        [Required(ErrorMessage = "Please Enter your Age")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Please Enter your Address")]
        public string Address { get; set; }

    }


}