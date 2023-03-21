using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDay1.Filter;
using WebAPIDay1.Models;

namespace WebAPIDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Cars>> GetALL()
        {
            //return Ok(Cars.GetCars());
           // _logger.LogWarning("this is a critical log");
            return Cars.GetCars(); //works because there is an implicit casting that happens in ActionREsult

        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Cars> Get(int id)
        {
            return Ok(Cars.GetCars().FirstOrDefault(car => car.Id == id));
        }

        

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<Cars> Edit(Cars car , int id)
        {

            if(car.Id != id)
            {
                return NotFound();
            }

            Cars CarToEdit = Cars.GetCars().First(car => car.Id == id);

            if (CarToEdit is null) 
            {
                return NotFound(new { message = "not found wrong data" });  
            };

            CarToEdit.Name = car.Name;
            CarToEdit.Model = car.Model;

            return NoContent();

        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<Cars> Delete(int id)
        {

          Cars CarToDelete = Cars.GetCars().First(c => c.Id == id);

          if(CarToDelete is null) { return NotFound(); }

            Cars.GetCars().Remove(CarToDelete);

            return NoContent();

        }



        [HttpPost]
        [Route("v1")]
        public ActionResult<Cars> Add(Cars car)
        {

            car.Id = new Random().Next(1, 100);
            Cars.GetCars().Add(car);
            return CreatedAtAction(actionName: nameof(Get), routeValues: new { id = car.Id }, value: "A Resourse has been added");
        }

        [HttpPost]
        [Route("v2")]
        [ServiceFilter(typeof(CarTypeFilterAttribute))]
        public ActionResult<Cars> AddV2(Cars car)
        {

            car.Id = new Random().Next(1, 100);
            Cars.GetCars().Add(car);
            return CreatedAtAction(actionName: nameof(Get), routeValues: new { id = car.Id }, value: "A Resourse has been added");
        }

    }
}
