using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Entities;
using POS.Model;
using System;
using System.Collections.Generic;

namespace POS.Areas.Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController(POSDbContext context) : ControllerBase
    {
        private readonly POSDbContext _Context = context;

        #region SUPPLIER

        [HttpGet("Data")]
        public async Task<IActionResult> GetDataAsync()
        {
            try
            {
                var list = await _Context.Suppliers.ToListAsync();
                return Ok(new ApiResponseModel()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Success = true,
                    Data = list,
                    Meassage = "Request Success"
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

        /// <summary>
        /// Create Supplier
        /// </summary>
        /// <remarks>
        /// Crate Supplier with auto generate id
        /// </remarks>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateSupplier([FromForm] Supplier model)
        {
            try
            {
                Supplier supplier = new()
                {
                    SupplierName = model.SupplierName,
                    Address = model.Address,
                    Phone = model.Phone,
                    UpdateDate = DateTime.Now,
                };
                _Context.Suppliers.Add(supplier);
                await _Context.SaveChangesAsync();

                //HelloWorld();

                return Ok(new ApiResponseModel()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Success = true,
                    Data = supplier,
                    Meassage = "Request Success"
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


        [HttpPut("supplier/edit")]

        public async Task<IActionResult> EditSupplier([FromForm] Supplier model)
        {
            try
            {
                Supplier suppliers = await _Context.Suppliers.FirstOrDefaultAsync(i=>i.SupplierId == model.SupplierId);
                if(suppliers != null)
                {
                    suppliers.SupplierId = model.SupplierId;
                    suppliers.SupplierName = model.SupplierName;
                    suppliers.Address = model.Address;
                    suppliers.Phone = model.Phone;
                    suppliers.UpdateDate = DateTime.Now;
                }
                _Context.Attach(suppliers).State = EntityState.Modified;
                if (await _Context.SaveChangesAsync()>0)
                {
                    return Ok(new ApiResponseModel()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Success = true,
                        Data = new { message = "SuccessFully Edit" },
                        Meassage = "Request Success"
                    }) ;
                }
                else
                {
                    return BadRequest( new ApiResponseModel() {                        
                        Success = false,
                        Data =null,
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
                    Data = new { message = "Fail" },
                    Meassage = ex.Message
                });

            }
        }

        /// <summary>
        /// Get SupplierID
        /// </summary>
        /// <remarks>
        /// Get Supplier ID
        /// </remarks>
        /// <param name="Supplierid"></param>
        /// <returns></returns>
        [HttpGet("supplier/byid")]

        public async Task<IActionResult> GetSupplierID(int Supplierid)
        {
            var list = await _Context.Suppliers.FirstOrDefaultAsync(i=>i.SupplierId == Supplierid);
            return Ok(new ApiResponseModel()
            {
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Data = list,
                Meassage = "Requrest Successfully"
            });
        }

        [HttpDelete("supplier/delete")]
        public async Task<IActionResult> DeleteSupplier(int supplierID)
        {
            Supplier supplier = await _Context.Suppliers.FindAsync(supplierID);

            try
            {
                if(supplier != null)
                {
                    _Context.Suppliers.Remove(supplier);
                    await _Context.SaveChangesAsync();

                    return Ok(new ApiResponseModel()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Success = true,
                        Data = supplier,
                        Meassage = "Request Success"
                    }) ;
                }
                else
                {
                    return BadRequest(new ApiResponseModel() { 
                        StatusCode = StatusCodes.Status400BadRequest,
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
                    StatusCode=StatusCodes.Status500InternalServerError,
                    Success = false,
                    Data = null,
                    Meassage =ex.Message

                });
            }
        }
        #endregion

        /// <summary>
        /// Hello world method to print console.
        /// </summary>
        /// <remarks>
        /// Print console
        /// </remarks>
        [NonAction]
        public void HelloWorld()
        {
            Console.WriteLine("HELLO WORLD");
        }
    }

}
