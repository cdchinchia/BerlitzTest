using BerlitzTest.Data;
using BerlitzTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace BerlitzTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _productContext;
        private readonly ApplicationDBContextInMemory _productContextInMemory;
        

        public HomeController(ApplicationDBContext productContext, ApplicationDBContextInMemory productContextInMemory)
        {
            _productContext = productContext;
            _productContextInMemory = productContextInMemory;            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int? dataStorage = HttpContext.Session.GetInt32(nameof(DataStorages));

            if(dataStorage is null || dataStorage ==0)
                return View(await _productContext.Products.ToListAsync());

            return View(await _productContextInMemory.Products.ToListAsync());
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            int? dataStorage = HttpContext.Session.GetInt32(nameof(DataStorages));

            if (dataStorage is null || dataStorage == 0)
            {
                _productContext.Products.Add(product);
                await _productContext.SaveChangesAsync();                
            }
            else
            {
                _productContextInMemory.Products.Add(product);
                await _productContextInMemory.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int? dataStorage = HttpContext.Session.GetInt32(nameof(DataStorages));

            var product = (dataStorage is null || dataStorage == 0)?_productContext.Products.Find(id) :
                _productContextInMemory.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            int? dataStorage = HttpContext.Session.GetInt32(nameof(DataStorages));

            if (dataStorage is null || dataStorage == 0)
            {
                _productContext.Update(product);
                await _productContext.SaveChangesAsync();
            }
            else
            {
                _productContextInMemory.Update(product);
                await _productContextInMemory.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            int? dataStorage = HttpContext.Session.GetInt32(nameof(DataStorages));

            var product = (dataStorage is null || dataStorage == 0) ? _productContext.Products.Find(id) :
                _productContextInMemory.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarUsuario(int? id)
        {
            int? dataStorage = HttpContext.Session.GetInt32(nameof(DataStorages));

            if (dataStorage is null || dataStorage == 0)
            {
                var productDB = await _productContext.Products.FindAsync(id);
                if (productDB == null)
                {
                    return View();
                }

                _productContext.Products.Remove(productDB);
                await _productContext.SaveChangesAsync();
            }
            else
            {
                var productInMemory = await _productContextInMemory.Products.FindAsync(id);
                if (productInMemory == null)
                {
                    return View();
                }

                _productContextInMemory.Products.Remove(productInMemory);
                await _productContextInMemory.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}