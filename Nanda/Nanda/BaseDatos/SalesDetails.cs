using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Nanda.BaseDatos
{
    public class SalesDetails
    {
        [MaxLength(10), Unique]
        public int Id { get; set; }
        [MaxLength(10), Unique]
        public int Sale_Id { get; set; }
        [MaxLength(10), Unique]
        public int Product_Id { get; set; }
        [MaxLength(6)]
        public int Price { get; set; }
        [MaxLength(6)]
        public int Quantity { get; set; }
    }
}
