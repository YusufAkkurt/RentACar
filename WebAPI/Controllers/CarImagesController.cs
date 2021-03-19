using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-list-by-carid")]
        public IActionResult GetListByCarId(int carId)
        {
            var result = _carImageService.GetListByCarId(carId);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
