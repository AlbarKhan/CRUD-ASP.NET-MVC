using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class EmployeModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password {  get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Department {  get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }
        public string FullName
        {
            get
            {
                string fullName = FirstName + " " + LastName;
                return fullName;
            }
        }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                return age;
            }
        }
    }
}