﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetRentDetails();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("get-rental-by-carid")]
        public IActionResult GetRentalByCarId(int carId)
        {
            var result = _rentalService.GetRentalByCarId(carId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
