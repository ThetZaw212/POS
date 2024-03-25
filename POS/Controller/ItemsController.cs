using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Entities;
using POS.Model;

namespace POS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController(POSDbContext context) : ControllerBase
    {
        private readonly POSDbContext _context = context;

        #region ItemPost

        [HttpPost]

        public async Task<IActionResult> CreateItem([FromForm]Item model)
        {
           
            Item item = new()
            { 
                 ItemId = model.ItemId,
                 ItemName = model.ItemName,
                 ItemQty = model.ItemQty,
                 ItemPrice = model.ItemPrice,
                 CreatedDate = DateTime.Now,
                 UpdatDate = DateTime.Now,
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return Ok(new ApiResponseModel()
            {
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = item,
                Meassage = "Request Success"
            });
        }

       


        #endregion

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(string? id, [FromForm] Item model)
        {

            
            try
            {
                Item item = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == id);
                if (item != null)
                {
                    item.ItemId = model.ItemId;
                    item.ItemName = model.ItemName;
                    item.ItemQty = model.ItemQty;
                    item.ItemPrice = model.ItemPrice;
                    item.CreatedDate = model.CreatedDate;
                    item.UpdatDate = DateTime.Now;
                }
                _context.Attach(item).State = EntityState.Modified;

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(new ApiResponseModel()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Success = true,
                        Data = new { message = "Done" },
                        Meassage = "Request Success"
                    });
                }
                else
                {
                    return BadRequest(new ApiResponseModel()
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Success = false,
                        Data = null,
                        Meassage = "Request Fail"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseModel()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Data = "",
                    Meassage = ex.Message
                });
            }


        }

        //[HttpDelete("Delete/{id}")]
        //public async Task<IActionResult> Delete(string? id)
        //{
        //    try
        //    {
        //        Item item = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == id);
        //        if (item != null)
        //        {
        //            _context.Items.Remove(item);
        //            if (await _context.SaveChangesAsync() > 0)
        //            {
        //                return Ok(new ApiResponseModel()
        //                {
        //                    StatusCode = StatusCodes.Status200OK,
        //                    Success = true,
        //                    Data = new { message = "Item deleted successfully" },
        //                    Meassage = "Request Success"
        //                });
        //            }
        //            else
        //            {
        //                return BadRequest(new ApiResponseModel()
        //                {
        //                    StatusCode = StatusCodes.Status500InternalServerError,
        //                    Success = false,
        //                    Data = null,
        //                    Meassage = "Request Fail"
        //                });
        //            }
        //        }
        //        else
        //        {
        //            return NotFound(new ApiResponseModel()
        //            {
        //                StatusCode = StatusCodes.Status404NotFound,
        //                Success = false,
        //                Data = null,
        //                Meassage = "Item not found"
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseModel()
        //        {
        //            StatusCode = StatusCodes.Status500InternalServerError,
        //            Success = false,
        //            Data = null,
        //            Meassage = ex.Message
        //        });
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string? id)
        {
            try
            {
                var item = await _context.Items.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }

                _context.Items.Remove(item);
                await _context.SaveChangesAsync();

                return Ok(new ApiResponseModel()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Success = true,
                    Data = null,
                    Meassage = "Item deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponseModel()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Data = "",
                    Meassage = ex.Message
                });
            }
        }
    }

}
