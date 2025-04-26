using Examen01.Data;
using Examen01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen01.Controllers
{
    public class CarreraController : Controller
    {
        private readonly AppDbContext _db;
        public CarreraController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Carrera> objCarreraList = _db.Carrera.ToList();
            return View(objCarreraList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                _db.Carrera.Add(carrera);
                _db.SaveChanges();
                TempData["success"] = "Carrera creada satisfactoriamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (ModelState.IsValid) {
                return NotFound();
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Carrera? carreraFromDb = _db.Carrera.Find(id);
            if (carreraFromDb == null)
            {
                return NotFound();
            }
            return View(carreraFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Carrera carrera)
        {
            if (ModelState.IsValid) {
                _db.Carrera.Update(carrera);
                _db.SaveChanges();
                TempData["success"] = "Carrera editada satisfactoriamente";
                return RedirectToAction("Index");
            }
            return View(carrera);
        }
        public IActionResult Delete(int? id)
        {
            if (ModelState.IsValid) {
                return NotFound();
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Carrera? carreraFromDb = _db.Carrera.Find(id);
            if (carreraFromDb == null)
            {
                return NotFound();
            }
            return View(carreraFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (ModelState.IsValid) {
                return RedirectToAction("Index");
        }
            return View(new Carrera());
        }
    }
}


