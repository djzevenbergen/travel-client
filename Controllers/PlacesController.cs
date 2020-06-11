using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using Microsoft.AspNetCore.Identity;

namespace TravelClient.Controllers
{
  public class PlacesController : Controller
  {
    // private readonly UserManager<ApplicationUser> _userManager;

    // public PlacesController(UserManager<ApplicationUser> userManager)
    // {
    //   _userManager = userManager;
    // }
    
    public IActionResult Index()
    {
      var allPlaces = Place.GetPlaces();
      return View(allPlaces);
    }

    [HttpPost]
    public IActionResult Index(Place place)
    {
      Place.Post(place);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var thisPlace = Place.GetDetails(id);
      var ratings = Rating.GetAll();
      ViewBag.Ratings = new List<Rating>{};
      foreach (Rating r in ratings) 
        {
          if (r.PlaceId == id)
          {
            ViewBag.Ratings.Add(r);
          }
        }
      return View(thisPlace);   
    }  
    public IActionResult Edit(int id)
    {
      var place = Place.GetDetails(id);
      return View(place);
    }

    [HttpPost]
    public IActionResult Details(int id, Place place)
    {
      place.PlaceId = id;
      Place.Put(place);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Place.Delete(id);
      return RedirectToAction("Index");
    }
  }
}