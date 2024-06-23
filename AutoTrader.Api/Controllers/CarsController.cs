using AutoTrader.Api.Models;
using AutoTrader.Models.CarInfo;
using Microsoft.AspNetCore.Mvc;

namespace AutoTrader.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository carRepository;
        public CarsController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetCars()
        {
            try
            {
                return Ok(await carRepository.GetCars());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving DATA FROM THE Database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarDetails>> GetCar(int id)
        {
            try
            {
                var result = await carRepository.GetCar(id);
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
        public async Task<ActionResult<CarDetails>> CreateCar(CarDetails carDetails)
        {
            try
            {
                if (carDetails == null)
                {
                    return BadRequest();
                }

                var createdCar = await carRepository.AddCar(carDetails);
                return CreatedAtAction(nameof(GetCar), new { id = createdCar.CarId }, createdCar);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving from the database");
            }
        }
        [HttpPut]
        public async Task<ActionResult<CarDetails>> UpdateCar(CarDetails carDetails)
        {
            try
            {

                var carToUpdate = carRepository.GetCar(carDetails.CarId);
                if (carToUpdate == null)
                {
                    return NotFound($"Car with Id={carDetails.CarId} not found");

                }
                return await carRepository.UpdateCar(carDetails);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error ");
            }
        }

    }
}