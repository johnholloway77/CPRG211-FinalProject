using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3_Final.Services
{
    internal interface ImySqlConnectable
    {

        void LoadFromDatabase(); //Method is to be used to load the database records from the respective table and put them into a List<T>
       

    }
}
