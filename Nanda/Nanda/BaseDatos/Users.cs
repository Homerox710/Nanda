﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Nanda.BaseDatos
{
    class Users //Tabla para usuarios
    {
        [MaxLength(30), Unique]
        public String Username { get; set; }
        [MaxLength(50)]
        public String Full_Name { get; set; }
        [MaxLength(40), Unique]
        public String Email { get; set; }
        [MaxLength(30)]
        public String Password { get; set; }
        [MaxLength(12)]
        public int Phone { get; set; }
    }
}
