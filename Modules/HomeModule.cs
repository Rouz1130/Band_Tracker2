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

    }
  }
}
