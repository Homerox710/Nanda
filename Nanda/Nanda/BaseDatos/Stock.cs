using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Nanda.BaseDatos
{
    class Stock
    {
        [MaxLength(10), Unique]
        public int Id { get; set; }
        [MaxLength(10), Unique]
        public int Product_Id { get; set; }
        [MaxLength(10)]
        public int Category_Id { get; set; }
        [MaxLength(6)]
        public int Quantity_Stock { get; set; }
    }
}
