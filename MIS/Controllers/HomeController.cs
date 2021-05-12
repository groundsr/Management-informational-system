﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MIS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            if(roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult() == false)
            {
                var adminRole = new IdentityRole();
                adminRole.Name = "Admin";
                adminRole.NormalizedName = "ADMIN";
                roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            }
            if (roleManager.RoleExistsAsync("Policeman").GetAwaiter().GetResult() == false)
            {
                var adminRole = new IdentityRole();
                adminRole.Name = "Policeman";
                adminRole.NormalizedName = "POLICEMAN";
                roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            }

            var admins = userManager.GetUsersInRoleAsync("Admin").GetAwaiter().GetResult();
            if (admins.Count == 0)
            {
                IdentityUser admin = new IdentityUser() { Email = "admin@admin.com", UserName = "admin@admin.com", EmailConfirmed = true };
                userManager.CreateAsync(admin, "P@ssw0rd").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
            }
            if (user != null)
            {
                var isAdmin = userManager.IsInRoleAsync(user, "Admin").GetAwaiter().GetResult();

                if (isAdmin)
                {
                    return RedirectToAction("Index", "PoliceSection");
                }
                return RedirectToAction("Index", "CriminalRecord");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
