using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMonolithic.ApplicationServices;
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;

namespace MvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApplicationService _personApplicationService;

        #region(- Ctor -)
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }
        #endregion

        #region(- Index() -)
        public async Task<IActionResult> Index()
        {
            var result = await _personApplicationService.GetAllPerson();
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
        public async Task<IActionResult> Create(PostPersonDto postPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Post(postPersonDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postPersonDto);

            }
        }
        #endregion

        #region (- Details() -)
        public async Task<IActionResult> Details(int id)
        {
            var result = await _personApplicationService.GetPersonById(id);

            if (result == null) return NotFound();

            return View(result);

        }

        #endregion

        #region(- Edit() - Get -)
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _personApplicationService.GetPersonById(id);

            if (result == null) return NotFound();

            return View(result);
        }

        #endregion

        #region(- Edit() - Post -)
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(PutPersonDto putPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Put(putPersonDto);

                return RedirectToAction(nameof(Index));
            }

            return View(putPersonDto);
        }

        #endregion

        #region(- Delete() - Get -)
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personApplicationService.GetPersonById(id);
            if (result == null) return NotFound();
            return View(result);
        }

        #endregion

        #region(- Delete() - Post -)

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personApplicationService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
