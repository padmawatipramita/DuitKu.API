using Binus.WS.Pattern.Output;
using Binus.WS.Pattern.Service;
using Duitku_API.Model;
using Duitku_API.Output;
using Microsoft.AspNetCore.Mvc;

namespace Duitku_API.Services
{
    [ApiController]
    [Route("user")]
    public class UserService : BaseService
    {
        public UserService(ILogger<BaseService> logger) : base(logger)
        {
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserDetail), StatusCodes.Status200OK)]
        public IActionResult GetAllUser()
        {
            try
            {
                var objJSON = new UserOutput();
                objJSON.Data = Helper.UserHelper.GetAllUser();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserOutput), StatusCodes.Status200OK)]
        public IActionResult AddNewItem([FromBody] UserDetail data)
        {
            try
            {
                var objJSON = new UserOutput();
                objJSON.Success = Helper.UserHelper.AddNewUser(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }

        [HttpPatch]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserOutput), StatusCodes.Status200OK)]
        public IActionResult ChangePersonalData([FromBody] msUser data)
        {
            try
            {
                var objJSON = new UserOutput();
                objJSON.Success = Helper.UserHelper.ChangePersonalData(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }
    }
}
