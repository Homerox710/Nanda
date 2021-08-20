using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Nanda.BaseDatos
{
    public class Sales
    {
        [MaxLength(10), Unique]
        public int Id { get; set; }
        [MaxLength(30), Unique]
        public String User { get; set; }
        [MaxLength(10)]
        public int Amount { get; set; }
        public DateTime Sell_Time { get; set; }
        [MaxLength(10)]
        public int Credit { get; set; }
        public DateTime Last_Payment { get; set; }
    }
}
