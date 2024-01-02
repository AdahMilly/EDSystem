using AutoMapper;
using EDSystem.Models;
using EDSystem.Models.Dtos;
namespace EDSystem.Profiles
{
    public class CourseProfiles:Profile
    {
        public CourseProfiles()
        {
            CreateMap<AddCourseDto, Course>().ReverseMap();
        }
        
    }
}
