using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspDotNetCoreWebApi.DAL;
using AspDotNetCoreWebApi.BO;

namespace AspDotNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentDAL _dal;
        public StudentsController(ILogger<StudentsController> logger, IStudentDAL dal)
        {
            _logger = logger;
            _dal = dal;
        }

        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(IEnumerable<StudentBO>), statusCode: 200)]



        [HttpGet("GetAllStudents")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_dal.GetStudents());
            }
            catch (Exception e)
            {
                _logger.LogError(exception:e,e.Message,null);
                return Problem(statusCode: 500, detail: e.Message);
            }
        }

        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(StudentBO), statusCode: 200)]
        [HttpGet("GetStudentbyId")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                if (id<=0)
                {
                    IEnumerable<string> validationErrors = new string[] { "Validation Error- Id should greater than zero" };
                    return BadRequest(validationErrors);
                }
                return Ok(_dal.GetStudent(id));
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, e.Message, null);
                return Problem(statusCode: 500, detail: e.Message);
            }
        }
        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(string), statusCode: 200)]

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(StudentBO student)
        {
            if (!String.IsNullOrEmpty(student.FirstName) && !String.IsNullOrEmpty(student.LastName) && student.RollNo != null)
            {
                _dal.CreateStudent(student);
                string success = "Student was created successfully";
                return Ok(success);
            }
            else
            {
                IEnumerable<string> validationErrors = new string[] { "Validation Error-Please fill First Name, Last Name, Roll No" };
                return BadRequest(validationErrors);
            }
            return Ok();
        }

        
        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(string), statusCode: 200)]

        
        [HttpPost("EditStudent")]
        public IActionResult EditStudent(StudentBO student)
        {
            if (!String.IsNullOrEmpty(student.FirstName) && !String.IsNullOrEmpty(student.LastName) && student.RollNo != null)
            {
                _dal.UpdateStudentbyId(student);
                string success = "Student edited successfully";
                return Ok(success);
            }
            else
            {
                IEnumerable<string> validationErrors = new string[] { "Validation Error-Please fill First Name, Last Name, Roll No" };
                return BadRequest(validationErrors);
            }
            return Ok(_dal.GetStudents());
        }

        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(string), statusCode: 200)]

        [HttpDelete("DeleteStudent")]
        public ActionResult DeleteStudent(int Id)
        {
            _dal.DeleteStudent(Id);
            string success = "Student deleted successfully";
            return Ok(success);
        }

    }

}
