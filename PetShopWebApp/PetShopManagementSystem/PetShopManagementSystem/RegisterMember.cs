using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PetShopManagementSystem
{
    public class RegisterMember
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long  MobileNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }

        public void RegisterUser(RegisterMember member)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString()))
            {
                string sql = @"INSERT INTO RegistrationTable   
                             (FirstName, MiddleName, LastName, EmailId, MobileNumber, UserName,Password,ConfirmPassword,Address,Age,Gender,Country)   
                              VALUES  
                             (@FirstName,@MiddleName, @LastName, @EmailId, @MobileNumber, @UserName,@Password,@ConfirmPassword,@Address,@Age,@Gender,@Country)";

                using (SqlCommand sqlCmd = new SqlCommand(sql, sqlConn))
                {
                    sqlCmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                    sqlCmd.Parameters.AddWithValue("@MiddleName", member.MiddleName);
                    sqlCmd.Parameters.AddWithValue("@LastName", member.LastName);
                    sqlCmd.Parameters.AddWithValue("@EmailId", member.EmailId);
                    sqlCmd.Parameters.AddWithValue("@MobileNumber", member.MobileNumber);
                    sqlCmd.Parameters.AddWithValue("@UserName", member.UserName);
                    sqlCmd.Parameters.AddWithValue("@Password", member.Password);
                    sqlCmd.Parameters.AddWithValue("@ConfirmPassword", member.ConfirmPassword);
                    sqlCmd.Parameters.AddWithValue("@Address", member.Address);
                    sqlCmd.Parameters.AddWithValue("@Age", member.Age);
                    sqlCmd.Parameters.AddWithValue("@Gender", member.Gender);
                    sqlCmd.Parameters.AddWithValue("@Country", member.Country);


                    sqlConn.Open();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }
    }
    
}