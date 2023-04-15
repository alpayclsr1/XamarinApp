using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    public class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }


        public byte[] Photo { get; set; }
    }
}
