using Binus.WS.Pattern.Output;
using Binus.WS.Pattern.Service;
using Duitku_API.Model;
using Duitku_API.Output;
using Microsoft.AspNetCore.Mvc;

namespace Duitku_API.Services
{
    [ApiController]
    [Route("transaction")]
    public class TransactionService : BaseService
    {
        public TransactionService(ILogger<BaseService> logger) : base(logger)
        {
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TransactionOutput), StatusCodes.Status200OK)]
        public IActionResult AddNewItem([FromBody] trTransaction data)
        {
            try
            {
                var objJSON = new TransactionOutput();
                objJSON.Success = Helper.TransactionHelper.AddNewTransaction(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TransOutput), StatusCodes.Status200OK)]
        public IActionResult GetAllTransaction()
        {
            try
            {
                var objJSON = new TransOutput();
                objJSON.Data = Helper.TransactionHelper.GetAllTransaction();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }
    }
}
