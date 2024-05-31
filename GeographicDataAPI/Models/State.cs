namespace GeographicDataAPI.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; } // Foreign key
        public Country Country { get; set; } // Navigation property
        public List<District> Districts { get; set; } = new List<District>();
    }
}
