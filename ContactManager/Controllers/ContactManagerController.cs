using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class ContactManagerController : Controller
    {
        public ContactManagerController()
        {
            
        }

        public IActionResult UploadCsv()
        {
            return View();
        }
    }
}
