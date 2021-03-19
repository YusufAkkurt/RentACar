using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-car-details")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-cars-by-brandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-cars-by-colorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("update-transactional-operation")]
        public IActionResult UpdateTransactionalOperation(Car car)
        {
            var result = _carService.UpdateTransactionalOperation(car);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
