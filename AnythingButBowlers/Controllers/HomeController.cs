using AnythingButBowlers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnythingButBowlers.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo;

        //Constructors
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }


        //View ALl Bowlers
        public IActionResult Index()
        {
            List<Bowler> allBowlers = _repo.Bowlers
                .ToList();

            ViewBag.AllBowlers = allBowlers;

            return View();
        }

        //When Bowler is added
        [HttpGet]
        public IActionResult AddBowler(int bowlerId)
        {
            ViewBag.BowlerID = bowlerId;
            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveBowler(bowler);

                return RedirectToAction("Index");
            }
            return View();
        }

        //When Bowler info is edited
        [HttpGet]
        public IActionResult EditBowler(int bowlerId)
        {
            Models.Bowler bowler = _repo.Bowlers.Where(x => x.BowlerID == bowlerId).FirstOrDefault();

            return View(bowler);
        }

        //When Bowler is deleted
        [HttpGet]
        public IActionResult DeleteBowler(int bowlerId)
        {
            _repo.DeleteBowler(bowlerId);

            return RedirectToAction("Index");
        }





    }
}
