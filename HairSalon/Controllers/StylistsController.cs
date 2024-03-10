using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
      // ViewBag.PageTitle = "Stylist List";
      return View(model);
    }

    public ActionResult Create()
    { 
      var specialties = new List<SelectListItem>
      {
        new SelectListItem { Value = "Short Hair", Text = "Short Hair" },
        new SelectListItem { Value = "Long Hair", Text = "Long Hair" },
        new SelectListItem { Value = "Haircut/Trim", Text = "Haircut/Trim" },
        new SelectListItem { Value = "Hair Coloring/Bleaching", Text = "Hair Coloring/Bleaching" },
        new SelectListItem { Value = "Hair Treatment/Consultation", Text = "Hair Treatment/Consultation" }
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

    public ActionResult Details(int id)
    {
      Stylist stylist = _db.Stylists.Include(s => s.Clients).FirstOrDefault(s => s.StylistId == id);
      return View(stylist);
    }

    public ActionResult Edit(int id)
    {
      Stylist stylist = _db.Stylists.FirstOrDefault(s => s.StylistId == id);
      var specialties = new List<SelectListItem>
      {
        new SelectListItem { Value = "Short Hair", Text = "Short Hair" },
        new SelectListItem { Value = "Long Hair", Text = "Long Hair" },
        new SelectListItem { Value = "Haircut/Trim", Text = "Haircut/Trim" },
        new SelectListItem { Value = "Hair Coloring/Bleaching", Text = "Hair Coloring/Bleaching" },
        new SelectListItem { Value = "Hair Treatment/Consultation", Text = "Hair Treatment/Consultation" }
      };
      ViewBag.Specialties = specialties;
      return View(stylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      _db.Stylists.Update(stylist);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = stylist.StylistId });
    }

    public ActionResult Delete(int id)
    {
      Stylist stylist = _db.Stylists.FirstOrDefault(s => s.StylistId == id);
      if (stylist == null)
      {
        return NotFound();
      }
      return View(stylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteCompleted(int id)
    {
      Stylist stylist = _db.Stylists.FirstOrDefault(s => s.StylistId == id);
      _db.Stylists.Remove(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}