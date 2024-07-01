using System;
using System.Collections.Generic;
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
        public bool IsDeleted { get; set; }

    }
}