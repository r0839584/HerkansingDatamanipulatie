using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_MAL_Models;

namespace Project_MAL_DAL
{
    public partial class Character : BasisKlasse
    {
        public string FullName => $"{this.name} {this.lastname}";

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "name" && name.Length < 1)
                {
                    return "Name needs to be atleast 1 character long";
                }
                if (columnName == "lastname" && lastname.Length < 1)
                {
                    return "Lastname needs to be atleast 1 character long";
                }
                return "";
            }
        }
    }
}
