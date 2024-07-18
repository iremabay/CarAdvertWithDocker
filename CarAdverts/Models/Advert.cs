namespace CarAdverts.Models
{
    public class Advert
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public int Km {  get; set; }
        public string Color { get; set; }
        public string Gear { get; set; }
        public string Fuel { get; set; }
        public string FirstPhoto { get; set; }

    }
}
