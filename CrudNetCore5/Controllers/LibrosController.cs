using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Libro> listLibros = _context.Libros;
            return View(listLibros);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }
        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if(ModelState.IsValid)
            {
                _context.Libros.Add(libro);
                _context.SaveChanges();


                TempData["Mensaje"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libros.Find(id);

            if (libro == null) {
                return NotFound();
            }
            

            return View(libro);
        }

        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Update(libro);
                _context.SaveChanges();


                TempData["Mensaje"] = "El libro se ha actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var libro = _context.Libros.Find(id);

            if (libro == null)
            {
                return NotFound();
            }


            return View(libro);
        }

        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null) 
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            _context.SaveChanges();


            TempData["Mensaje"] = "El libro se ha eliminado correctamente";
            return RedirectToAction("Index");
            
        }





    }
}
