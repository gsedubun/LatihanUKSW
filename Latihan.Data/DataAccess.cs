using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using Npgsql;

namespace Latihan.Data
{
    public class DataAccess
    {
        public string AmbilMakan(){
            return "Nasi goreng";
            // return 1 ;
        }
        public IEnumerable<TabelUser> GetUser(){
            string connstr = @"Host=localhost; port=5432;Database=TrainingUKSW;
                user id=postgres;password=postgres";
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
