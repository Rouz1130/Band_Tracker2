using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/bands"] = _ => {
      List<Band> AllBands = Band.GetAll();
      return View["bands.cshtml", AllBands];
    };

    Get["/bands/new"] = _ => {
    return View["bands_form.cshtml"];
    };

    Post["/bands/new"] = _ => {
        Band newBand = new Band(Request.Form["band-name"]);
        newBand.Save();
        return View["success.cshtml"];
      };

      Post["/bands/delete"] = _ => {
        Band.DeleteAll();
        return View["cleared.cshtml"];
      };


      Get["/venues"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["venues.cshtml", AllVenues];
      };

      Get["/venues/new"] = _ => {
      return View["venues_form.cshtml"];
    };

    Post["/venues/new"] = _ => {
      Venue newVenue = new Venue(Request.Form["venue-name"]);
      newVenue.Save();
      return View["success.cshtml"];
    };



    }
  }
}
