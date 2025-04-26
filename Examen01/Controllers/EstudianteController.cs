using Examen01.Data;
using Examen01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen01.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly AppDbContext _db;
        public EstudianteController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Estudiante> objEstudianteList = _db.Estudiante.ToList();
            return View(objEstudianteList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _db.Estudiante.Add(estudiante);
                _db.SaveChanges();
                TempData["success"] = "Estudiante creado satisfactoriamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Estudiante? EstudianteFromDb = _db.Estudiante.Find(id);
            if (EstudianteFromDb == null)
            {
                return NotFound();
            }
            return View(EstudianteFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _db.Estudiante.Update(estudiante);
                _db.SaveChanges();
                TempData["success"] = "Estudiante editado satisfactoriamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Estudiante? EstudianteFromDb = _db.Estudiante.Find(id);
            if (EstudianteFromDb == null)
            {
                return NotFound();
            }
            return View(EstudianteFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Estudiante? estudiante = _db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            _db.Estudiante.Remove( estudiante);
            _db.SaveChanges();
            TempData["success"] = "Categoria eliminada satisfactoriamente";
            return RedirectToAction("Index");
        }

    }
}
