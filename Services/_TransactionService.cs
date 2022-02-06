using Binus.WS.Pattern.Output;
using Binus.WS.Pattern.Service;
using DuitKu.API.Model;
using DuitKu.API.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DuitKu.API.Services
{
    [ApiController]
    [Route("transaction")]
    public class _TransactionService : BaseService
    {
        public _TransactionService(ILogger<BaseService> logger) : base(logger)
        {
        }

        // ADD NEW TRANSACTIONS
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(_TransactionOutput), StatusCodes.Status200OK)]
        public IActionResult AddNewItem([FromBody] _TransactionModel data)
        {
            try
            {
                var objJSON = new _TransactionOutput();
                objJSON.Success = Helper._TransactionHelper.AddNewTransaction(data);
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }

        // GET ALL TRANSACTIONS
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TransOutput), StatusCodes.Status200OK)]
        public IActionResult GetAllTransaction()
        {
            try
            {
                var objJSON = new TransOutput();
                objJSON.Data = Helper._TransactionHelper.GetAllTransaction();
                return new OkObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OutputBase(ex));
            }
        }
    }
}