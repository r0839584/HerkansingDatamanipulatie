using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_MAL_Models;

namespace Project_MAL_DAL
{
    public partial class Manga: BasisKlasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "name" && name.Length < 1)
                {
                    return "Name needs to be atleast 1 character long";
                }
                if (columnName == "chapters" && chapters <= 0)
                {
                    return "Manga needs to have atleast one chapter!";
                }
                return "";
            }
        }
    }
}
