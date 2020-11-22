using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sogeti_Client_Data_Repository.Models
{
    public class testClass
    {
        string name;
        int age;
        string email;

        public testClass(string name, int age, string email)
        {
            this.name = name;
            this.age = age;
            this.email = email;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Email { get => email; set => email = value; }
    }
}
