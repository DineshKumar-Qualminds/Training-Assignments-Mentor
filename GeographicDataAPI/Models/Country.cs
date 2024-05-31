namespace GeographicDataAPI.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<State> States { get; set; } = new List<State>();
    }
}
