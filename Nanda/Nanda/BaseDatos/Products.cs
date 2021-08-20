using SQLite;

namespace Nanda.BaseDatos
{
    class Products
    {
        [MaxLength(10), Unique]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Brand { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }
        [MaxLength(6)]
        public int Price { get; set; }
        [MaxLength(10), Unique]
        public int Category_Id { get; set; }
    }
}
