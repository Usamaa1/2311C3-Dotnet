using BasicsWithDBProject.Data;
using BasicsWithDBProject.Models;
using Microsoft.AspNetCore.Mvc;
namespace BasicsWithDBProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly Db2311C3Context _context;
        public StudentController(Db2311C3Context context)
        {
            _context = context;
        }
        public IActionResult AddStudent()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                    _context.Add(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Item Added Successfully";
                    ModelState.Clear();
                    return View();
            }
            return View();
        }
        public IActionResult StudentView() 
        {
            var student = _context.Students.ToList();
            return View(student);
        }



        public IActionResult StudentDelete(int delId)
        {
          var std =  _context.Students.Find(delId);
            _context.Students.Remove(std);
            _context.SaveChanges();
            return Redirect("StudentView");
        }




    }
}
