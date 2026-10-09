using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;

namespace MvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        #region(- Ctor -)
        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }
        #endregion

        #region(- Index() -)
        public async Task<IActionResult> Index()
        {
            var result = await _productApplicationService.GetAllProduct();
            return View(result);
        }

        #endregion

        #region(- Create() - Get -)
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        #endregion

        #region(- Create() - Post -)
        public async Task<IActionResult> Create(PostProductDto postProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.Post(postProductDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postProductDto);

            }
        }

        #endregion

        #region (- Details() -)
        public async Task<IActionResult> Details(int id)
        {
            var result = await _productApplicationService.GetProductById(id);

            if (result == null) return NotFound();

            return View(result);

        }

        #endregion

        #region(- Edit() - Get -)
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _productApplicationService.GetProductById(id);

            if (result == null) return NotFound();

            return View(result);
        }

        #endregion

        #region(- Edit() - Post -)
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(PutProductDto putProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.Put(putProductDto);

                return RedirectToAction(nameof(Index));
            }

            return View(putProductDto);
        }

        #endregion

        #region(- Delete() - Get -)
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productApplicationService.GetProductById(id);
            if (result == null) return NotFound();
            return View(result);
        }

        #endregion

        #region(- Delete() - Post -)

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productApplicationService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}

