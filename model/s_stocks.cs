using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class s_stocks
    {

        public int Id { get; set; }

        public string stock_code { get; set; }

        public int stock_price { get; set; }

        public bool is_active { get; set; }
    }
}
