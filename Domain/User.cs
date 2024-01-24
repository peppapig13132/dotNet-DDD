using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string gender {  get; set; }
        public int age { get; set; }

        public User(string name, string email, string gender,int age)
        {
            this.name = name;
            this.email = email;
            this.gender = gender;
            this.age = age;
        }
        public void Update(string name,string email,string gender,int age)
        {
            this.name = name;  
            this.email = email;
            this.gender = gender;
            this.age = age;
        }
    }
}
