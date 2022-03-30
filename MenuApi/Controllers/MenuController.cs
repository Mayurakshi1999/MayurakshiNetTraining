using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MenuApi.BO;
using MenuApi.DAL;
using MenuApi.DB;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    ////[ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuDAL _dal;
        public MenuController(ILogger<MenuController> logger, IMenuDAL dal)
        {
            _logger = logger;
            _dal = dal;
        }

        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(IEnumerable<MenuBO>), statusCode: 200)]

        //get all the students
        [HttpGet("GetMenu")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_dal.GetMenu());
                //return BadRequest(); for validation
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, e.Message, null);
                //throw e;
                return Problem(statusCode: 500, detail: e.Message);
            }
        }
        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(IEnumerable<MenuBO>), statusCode: 200)]

        [HttpGet("GetChoice")]
        public IActionResult GetChoice()
        {
            try
            {
                return Ok(_dal.GetChoice());
                //return BadRequest(); for validation
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, e.Message, null);
                //throw e;
                return Problem(statusCode: 500, detail: e.Message);
            }
        }
        [ProducesResponseType(statusCode: 500)]
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)]
        [ProducesResponseType(type: typeof(IEnumerable<MenuBO>), statusCode: 200)]

        [HttpGet("GetMenuCard")]
        public IActionResult GetMenuCard(int Mid, int Cid)
        {
            try
            {
                return Ok(_dal.GetMenuCard(Mid, Cid));
                //return BadRequest(); for validation
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, e.Message, null);
                //throw e;
                return Problem(statusCode: 500, detail: e.Message);
            }

        }
        //add dishes post method.
        [ProducesResponseType(statusCode: 500)] //exceptions
        [ProducesResponseType(type: typeof(IEnumerable<string>), statusCode: 400)] //validation errors
        [ProducesResponseType(type: typeof(string), statusCode: 200)] //success
        [HttpPost("AddDish")]
        public IActionResult AddDish(MenuCardBO dish)
        {

            if (!string.IsNullOrEmpty(dish.DishName) && dish.Price != null)
            {
                _dal.AddDish(dish);
                string Successmsg = "The dish was added successfully";
                return Ok(Successmsg);
            }
            else
            {
                IEnumerable<string> validationErrors = new string[] { "Validation error- DishName and Price required" };
                return BadRequest(validationErrors);
            }
            return Ok();
        }


    }
}


