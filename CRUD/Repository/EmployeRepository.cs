﻿using System;
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

        public void InsertEmployee(EmployeModel employe)
        {

            using(IDbConnection dbConnection = Connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", employe.FirstName);
                parameters.Add("@LastName", employe.LastName);
                parameters.Add("@Department", employe.Department);
                parameters.Add("@Email", employe.Email);
                parameters.Add("@Phone", employe.Phone);
                parameters.Add("@BirthDate", employe.BirthDate);
                parameters.Add("@UserName", employe.UserName);
                parameters.Add("@Password", employe.Password);
                dbConnection.Open();
                dbConnection.Execute("usp_Employees_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}