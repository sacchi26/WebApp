using CRUDApp.Data;
using CRUDApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApp.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          IEnumerable<Product> Products = _context.Products.ToList();
            return View(Products);
        }
        [HttpGet]
         
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create( [Bind("Name,Price,Description,Stock")]Product model)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Product = _context.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            else
            {
                return View(Product);
            }
        }

        [HttpPost]
        public IActionResult Edit([Bind(" Id,Name,Price,Description,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Product = _context.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            else
            {
                return View(Product);
            }
        }

        
        public IActionResult DeleteConfirm(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
