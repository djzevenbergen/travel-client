using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers
{
  public class RatingsController : Controller
  {

    public IActionResult Details(int id)
    {
      var thisRating = Rating.GetDetails(id);
      return View(thisRating);
    }

    public IActionResult Rate(int id)
    {
      var thisPlace = Place.GetPlaces().Where(p => p.PlaceId == id); 
      foreach(Place p in thisPlace) 
      {
        ViewBag.City = p.City;
        ViewBag.PlaceId = p.PlaceId;        
      }
      return View();
    }

    [HttpPost]
    public IActionResult Rate(Rating rating)
    {      
      Rating.Post(rating);
      return RedirectToAction("Details", "Places", new{id = rating.PlaceId});
    }

    public IActionResult Edit(int id)
    {
      var rating = Rating.GetDetails(id);
      return View(rating);
    }

    // [HttpPost]
    // public IActionResult Details(int id, Rating rating)
    // {
    //   rating.RatingId = id;
    //   Rating.Put(rating);
    //   return RedirectToAction("Details", id);
    // }

    public IActionResult Delete(int id)
    {
      Rating.DeleteRating(id);
      return RedirectToAction("Places/Details{placeId}");    }
  }
}