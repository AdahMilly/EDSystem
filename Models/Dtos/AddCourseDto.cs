namespace EDSystem.Models.Dtos
{
    //type we can be using whenever we want to add a new event
    public class AddCourseDto
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string url { get; set; }
    }
}
