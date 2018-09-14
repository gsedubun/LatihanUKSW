using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using Npgsql;

namespace Latihan.Data
{
    public class DataAccess
    {
        private static string connstr = @"Host=localhost; 
                port=5432;Database=TrainingUKSW;
                user id=postgres;password=postgres";
        public string AmbilMakan(){
            return "Nasi goreng";
            // return 1 ;
        }
        
        public IEnumerable<TabelUser> GetUser(){
            
            NpgsqlConnection connection = new NpgsqlConnection(connstr);
            connection.Open();
            var data = connection.Query<TabelUser>(@"SELECT user_id, 
                user_name,
                email,
                full_name,
                password
                FROM tr_user");
            connection.Close();
            return data;
        }

        public void InsertUser(TabelUser tabelUser)
        {
            NpgsqlConnection connection = new   NpgsqlConnection(connstr);
            string sqlInsert = @"INSERT INTO tr_user(user_name,
                full_name,email,password)
                VALUES(@user_name,@full_name,@email,@password)";
            var insert = connection.Execute(sqlInsert,new {
                user_name = tabelUser.user_name,
                full_name=tabelUser.full_name,
                email = tabelUser.email,
                password=tabelUser.password
            });

            
        }
    }
//VIEWMODEL TYPES
    public class TabelUser{
        public int user_id { get; set; }
        public string  user_name { get; set; }
        public string email{ get; set; }
        public string full_name{ get; set; }
        public string password{ get; set; }
    }
}
