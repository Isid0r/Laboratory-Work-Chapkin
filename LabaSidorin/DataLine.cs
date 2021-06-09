using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaSidorin
{
    class DataLine
    {
       public string UserName { get; set; }

       public string UserRole { get; set; }

        public DataLine(string line)
        {
            string[] split = line.Split(new Char[] {'-'});
            UserName = split[0];
            UserRole = split[1];
        }

        public override string ToString()
        {
            return UserName + "-" + UserRole;
        }

    }
}
