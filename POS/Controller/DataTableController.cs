using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Model;

namespace POS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTableController(POSDbContext context) : ControllerBase
    {
        private readonly POSDbContext _Context = context;

        [HttpGet("Items")]

        public async Task<IActionResult> GetStockItemAsync()
        {
            var list = await _Context.Items.ToListAsync();
            ApiResponseModel response = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = list,
                Meassage = "Request Success"
            };
            return Ok(response);
        }
    }
}
