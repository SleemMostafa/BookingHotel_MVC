using BookingHotel_MVC.Models;
using BookingHotel_MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel_MVC.Controllers
{
    public class BranchController : Controller
    {
        private readonly IServiceBranch serviceBranch;

        public BranchController(IServiceBranch serviceBranch)
        {
            this.serviceBranch = serviceBranch;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(serviceBranch.GetAll());
        }

        public IActionResult GetOne(int id)
        {
            return View(serviceBranch.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Branch branch)
        {
            int rowEffect = serviceBranch.Insert(branch);
            if (rowEffect > 0)
            {
                return RedirectToAction("Index");
            }
            return View(branch);
        }
    }
}
