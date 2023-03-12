using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Web_Api.RequiredData.GetDataTo
{
    public class GetResponse<T> where T : class
   { 
        public string ItemsCount { get; set; }
        public IEnumerable<T> Items { get; set; }
   }
}
