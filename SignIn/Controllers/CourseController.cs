using Microsoft.AspNetCore.Mvc;
using SignIn.Models;

namespace SignIn.Controllers;
public class CourseController : Controller
{
    public IActionResult Index()
    {
        return View(Repository.Applications);
    }
    public IActionResult Apply()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken] //For security
    public IActionResult Apply([FromForm]Candidate model)
    {
        if(Repository.Applications.Any(c => c.Email.Equals(model.Email))){
            ModelState.AddModelError("", "There is already an application for you.");
        }
        if(ModelState.IsValid)
        {
            Repository.Add(model);
        return View("Feedback",model);
        }
        return View();
        
    }
}