using labD01.Models;
using Microsoft.AspNetCore.Mvc;

namespace labD01.Controllers
{
    public enum Status
    {
        list,
        table
    }
    public class Data
    {
        public Car? car;
        public Status? status;
    }
    public class CarsController : Controller
    {
        public IActionResult GetAll()
        {
            var cars=Car.GetCars();
            return View(cars);
        }
        public IActionResult GetDetailsForCar(string cModel , Status? status)
        {
            var car = Car.GetCars().FirstOrDefault(c => c.Model == cModel);
            Data data= new Data();
            data.car = car;
            data.status = status;
            return View(data);
        }
    }
}
