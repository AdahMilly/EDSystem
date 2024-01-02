using AutoMapper;
using EDSystem.Models;
using EDSystem.Models.Dtos;
using EDSystem.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EDSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _courseService;
        private readonly IMapper _mapper;
        public CourseController(ICourse ev, IMapper mapper)
        {
            _courseService = ev;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses() { 
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }
        [HttpGet("id")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var course = await _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound("Course Not Found");
            }
            return Ok(course);
        }
        [HttpPut("id")]
        public async Task<ActionResult<string>> UpdateCourse(Guid id, AddCourseDto updateCourse)
        {
            var course = await _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound("Course Not Found");
            }
            var updatedCourse = _mapper.Map<Course>(updateCourse);
            var response = await _courseService.UpdateCourse(updatedCourse);
            return Ok(response);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<string>> DeleteCourse(Guid id)
        {
            var course = await _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound("Course Not Found");
            }
            var response = await _courseService.DeleteCourse(course);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddCourse(AddCourseDto courseDto)
        {
            //convert an instance of AddCourseDto to an instance of Course using automapper
            var newCourse = _mapper.Map<Course>(courseDto);
            var response = await _courseService.AddCourse(newCourse);
            return Created($"Courses/{newCourse.id}", response);
        }
    }
}
