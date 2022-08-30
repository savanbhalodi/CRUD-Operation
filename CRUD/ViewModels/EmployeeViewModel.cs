using CRUD.Models;
using CRUD.Models.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUD.ViewModels
{
    public class EmployeeViewModel
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(Appsettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllEmployees", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(reader["id"]);
                        employee.Name = reader["name"].ToString();
                        employee.Gender = reader["gender"].ToString();
                        employee.Age = Convert.ToInt32(reader["age"]);
                        employee.Salary = Convert.ToInt32(reader["salary"]);
                        employee.City = reader["city"].ToString();

                        employees.Add(employee);
                    }
                }
            }
                return employees;
        }

        public void UpdatesEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(Appsettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateEmployee", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("id", employee.Id);
                    cmd.Parameters.AddWithValue("@name", employee.Name);
                    cmd.Parameters.AddWithValue("@gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@age", employee.Age);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@city", employee.City);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //create
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(Appsettings.ConnectionString()))
            {
                //string str = "insert into employee_tbl values(@name,@gender,@age,@salary,@city)";
                using (SqlCommand cmd = new SqlCommand("AddEmployee", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@name",employee.Name);
                    cmd.Parameters.AddWithValue("@gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@age", employee.Age);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@city", employee.City);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Edit

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();

            using (SqlConnection conn = new SqlConnection(Appsettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetEmployeeById", conn))
                {
                   
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                                        
                    employee.Id = Convert.ToInt32(reader["id"]);
                    employee.Name = reader["name"].ToString();
                    employee.Gender = reader["gender"].ToString();
                    employee.Age = Convert.ToInt32(reader["age"]);
                    employee.Salary = Convert.ToInt32(reader["salary"]);
                    employee.City = reader["city"].ToString();
                }
            }
            return employee;
        }


        //Delete
        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(Appsettings.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteEmployee", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@id", id);
                 
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
