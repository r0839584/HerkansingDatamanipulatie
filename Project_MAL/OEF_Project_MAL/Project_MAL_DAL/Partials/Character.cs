using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_MAL_DAL
{
    public partial class Character
    {
        public override string ToString()
        {
            return this.name + " " + this.lastname;
        }
    }
}
