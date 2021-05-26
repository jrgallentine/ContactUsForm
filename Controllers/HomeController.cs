using BizStream.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BizStream.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string firstName, string lastName, string email, string message)
        {    
            Contact c = new Contact();
            c.FirstName = firstName;
            c.LastName = lastName;
            c.Email = email;
            c.Message = message;

            string filepath = @"ContactUs.txt";

            using StreamReader reader = new StreamReader(filepath);
            string fileOutput = reader.ReadToEnd();
            reader.Close();
            using StreamWriter writer = new StreamWriter(filepath);


            DateTime dt = DateTime.Now;
            writer.WriteLine(fileOutput);
            writer.WriteLine($"-----{dt}-----");
            writer.WriteLine($"Name: {firstName} {lastName}");
            writer.WriteLine($"Email: {email}");
            writer.WriteLine($"Message: {message}");
            writer.WriteLine();
            writer.Close();

            return View("Success",c);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
