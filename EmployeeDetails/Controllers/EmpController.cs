using Employee_Datamodel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeDetails.Controllers
{
    public class EmpController : Controller
    {
        public readonly EmpDbContext _empDb;
        public EmpController(EmpDbContext empDb)
        {
            _empDb = empDb;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _empDb.Employees.Add(employee);
            _empDb.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var emp = _empDb.Employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
            {
            _empDb.Attach(employee).State = EntityState.Modified;
            _empDb.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EmployeeDetails(int id)
        {
            var emp = _empDb.Employees.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }
        [HttpGet]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _empDb.Employees.Find(id);
            _empDb.Employees.Remove(emp);
            _empDb.SaveChanges();
            return View();
        }
    }
}
