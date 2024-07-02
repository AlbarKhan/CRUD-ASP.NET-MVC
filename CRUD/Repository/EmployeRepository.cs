using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CRUD.Models;
using Dapper;

namespace CRUD.Repository
{
    public class EmployeRepository
    {
        private string _connectionString;

        public EmployeRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultString"].ConnectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<EmployeModel> GetAllEmployee()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<EmployeModel>("usp_Employees_GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}