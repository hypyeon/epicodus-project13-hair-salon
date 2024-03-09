using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      ViewBag.PageTitle = "Stylist List";
      return View(model);
    }

    public ActionResult Create()
    { 
      var specialties = new List<SelectListItem>
      {
        new SelectListItem { Value = "1", Text = "Short Hair" },
        new SelectListItem { Value = "2", Text = "Long Hair" },
        new SelectListItem { Value = "3", Text = "Haircut/Trim" },
        new SelectListItem { Value = "4", Text = "Hair Coloring/Bleaching" },
        new SelectListItem { Value = "5", Text = "Hair Treatment/Consultation" }
      };
      ViewBag.Specialties = specialties;
      ViewBag.PageTitle = "Register Stylist";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}