using System;
using System.Collections;
using System.Collections.Generic;
using Dapper;
using Npgsql;

namespace Latihan.Data
{
    public class DataAccess
    {
        private string connstr;
        public DataAccess(string connStr)
        {
            this.connstr = connStr;
        }
        // private static string connstr = @"Host=localhost; 
        //         port=5432;Database=TrainingUKSW;
        //         user id=postgres;password=postgres";

        public IEnumerable<TabelRole> GetRoles()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connstr);
            connection.Open();
            var data = connection.Query<TabelRole>(@"SELECT role_id, role_name
                FROM tr_role");
            connection.Close();
            return data;
        }

        public int DeleteUser(int user_id)
        {
            NpgsqlConnection connection = new   NpgsqlConnection(connstr);
            string sqlDelete = @"DELETE FROM tr_user WHERE user_id=@user_id";
            int delete = connection.Execute(sqlDelete,new {
                    user_id=user_id
            });
            return delete;
        }


        public string AmbilMakan(){
            return "Nasi goreng";
            // return 1 ;
        }
        public TabelUser ValidateLogin(string username, string password){
            NpgsqlConnection connection = new NpgsqlConnection(connstr);
            
            var data= connection.QuerySingle<TabelUser>(@"SELECT user_id, 
                user_name,
                email,
                full_name,
                password
                FROM tr_user where user_name=@username and password=@password",
                 new {username, password});
            if(data!=null)
                return data;
                
            return null;
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
        public IEnumerable<VWUserRole> GetUserRoles(){
            NpgsqlConnection connection = new NpgsqlConnection(connstr);
            connection.Open();
            var data = connection.Query<VWUserRole>(@"SELECT user_name
                ,email
                ,full_name
                ,role_name
                FROM vw_user_role");
            connection.Close();
            return data;
        }

        public int InsertUser(TabelUser tabelUser)
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
            return insert;
        }

        public int InsertRole(TabelRole tabelRole)
        {
            NpgsqlConnection connection = new   NpgsqlConnection(connstr);
            string sqlInsert = @"INSERT INTO tr_role(role_name) VALUES(@role_name)";
            var insert = connection.Execute(sqlInsert,new {
                role_name = tabelRole.role_name,
            });
            return insert;
        }
        public int InsertUserRole(TabelUserRole tabelRole)
        {
            NpgsqlConnection connection = new   NpgsqlConnection(connstr);
            string sqlInsert = @"INSERT INTO tt_user_role(role_id,user_id)
                VALUES(@role_id,@user_id)";
            var insert = connection.Execute(sqlInsert,new {
                role_id = tabelRole.role_id,
                user_id=tabelRole.user_id
            });
            return insert;

        }
      
        
    }
}
