using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Web.Models;
using AsyncInn.Web.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Web.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelService hotelService;
        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        // GET: Hotels
        public async Task<ActionResult> Index()
        {
            var hotels = await hotelService.GetAll();
            return View(hotels.OrderBy(h => h.Name));
        }

        // GET: Hotels/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var hotel = await hotelService.GetOne(id);
            return View(hotel);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Hotel hotel)
        {
            try
            {
                await hotelService.Create(hotel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hotels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hotels/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
