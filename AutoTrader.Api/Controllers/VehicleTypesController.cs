using AutoTrader.Api.Models;
using AutoTrader.Models.CarInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrader.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypesController : ControllerBase
    {
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        public VehicleTypesController(IVehicleTypeRepository vehicleTypeRepository)
        {
            this.vehicleTypeRepository = vehicleTypeRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetVehicleTypes()
        {
            try
            {
                return Ok(await vehicleTypeRepository.GetVehicleTypes());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving DATA FROM THE Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VehicleType>> GetVehicleType(int id)
        {
            try
            {
                var result = await vehicleTypeRepository.GetVehicleType(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VehicleType>> CreateVehicleType(VehicleType vehicleType)
        {
            try
            {
                if (vehicleType == null)
                {
                    return BadRequest();
                }

                var createdVehicleType = await vehicleTypeRepository.CreateVehicleType(vehicleType);
                return CreatedAtAction(nameof(GetVehicleType), new { id = createdVehicleType.VehicleTypeId }, createdVehicleType);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving from the database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<VehicleType>> UpdateVehicleType(int id, VehicleType vehicleType)
        {
            try
            {
                if (id != vehicleType.VehicleTypeId)
                {
                    return BadRequest("No such type found");
                }
                var vehicleTypToUpdate = vehicleTypeRepository.GetVehicleType(id);
                if (vehicleTypToUpdate == null)
                {
                    return NotFound($"Vehicle Type with Id={id} not found");

                }
                return await vehicleTypeRepository.UpdateVehicleType(vehicleType);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error ");
            }
        }

    }
}
