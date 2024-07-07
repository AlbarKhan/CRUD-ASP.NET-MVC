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
        public string UserName { get; set; }
        public string Password {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
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