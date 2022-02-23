using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Consol_Final.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public double Balance { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }

    }
}
