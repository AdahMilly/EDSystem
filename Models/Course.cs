namespace EDSystem.Models
{
    public class Course
    {
        public Guid id { get; set; }   
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string url { get; set; }
    }
}
