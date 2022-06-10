﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CurdApplication.Models;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace CurdApplication.Controller
{
    class accountsContraller
    {
        string connection = ConfigurationManager.ConnectionStrings["testCrud"].ConnectionString;


        public List<accounts> GetAll()
        {
            var accounts = new List<accounts>();
            using (var dbConnection = new SqlConnection(connection))
            {
                using (var dbCommand = new SqlCommand())
                {
                    dbConnection.Open();
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandText = "Select * from accounts order by ID";
                    using (SqlDataReader reader = dbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var account = new accounts();
                            account.ID = (int)reader[0];
                            account.fName = reader[1].ToString();
                            account.lName = reader[2].ToString();
                            account.email = reader[3].ToString();
                            account.phone = (int)reader[4];
                            account.gender = reader[5].ToString();
                            accounts.Add(account);
                        }
                    }
                }
            }
            return accounts;
        }

        public void Add(accounts account)
        {
            using (var dbConnection = new SqlConnection(connection))
            {
                using (var dbCommand = new SqlCommand())
                {
                    dbConnection.Open();
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandText = @"insert into accounts (fristName, lastName,email,phoneNumber,gender)
                                            values
                                            (@fName, @lName, @email, @phone, @gender)";
                    dbCommand.Parameters.Add("@fName", SqlDbType.VarChar).Value = account.fName;
                    dbCommand.Parameters.Add("@lName", SqlDbType.VarChar).Value = account.lName;
                    dbCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = account.email;
                    dbCommand.Parameters.Add("@phone", SqlDbType.Int).Value = Convert.ToInt32(account.phone);
                    dbCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = account.gender;

                    dbCommand.ExecuteNonQuery();
                }
            }
        }

        public void Update(accounts account, int ID)
        {
            using (var dbConnection = new SqlConnection(connection))
            {
                using (var dbCommand = new SqlCommand())
                {
                    dbConnection.Open();
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandText = @"update accounts SET
		                                        fristName = @fName,
		                                        lastName = @lName,
		                                        email = @email,
		                                        phoneNumber = @phone,
		                                        gender = @gender
		                                            WHERE ID = @ID;";

                    dbCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToInt32(ID);

                    dbCommand.Parameters.Add("@fName", SqlDbType.VarChar).Value = account.fName;
                    dbCommand.Parameters.Add("@lName", SqlDbType.VarChar).Value = account.lName;
                    dbCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = account.email;
                    dbCommand.Parameters.Add("@phone", SqlDbType.Int).Value = Convert.ToInt32(account.phone);
                    dbCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = account.gender;

                    dbCommand.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int ID)
        {
            using (var dbConnection = new SqlConnection(connection))
            {
                using (var dbCommand = new SqlCommand())
                {
                    dbConnection.Open();
                    dbCommand.Connection = dbConnection;
                    dbCommand.CommandText = @"delete from accounts where ID = @ID;";

                    dbCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = Convert.ToInt32(ID);

                    dbCommand.ExecuteNonQuery();
                }
            }
        }


    }
}
