using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Nanda.BaseDatos
{
    class Categories
    {
        [MaxLength(10), Unique]
        public int Id { get; set; }
        [MaxLength(30), Unique]
        public String Name { get; set; }
        [MaxLength(100)]
        public String Description { get; set; }
    }
}
