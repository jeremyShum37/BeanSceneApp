﻿using BeanSceneApp.Models;
using BeanSceneApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;


    public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        var userRolesViewModel = new List<UserRolesViewModel>();

        foreach (var user in users)
        {
            var thisViewModel = new UserRolesViewModel();
            thisViewModel.UserId = user.Id;
            thisViewModel.Email = user.Email;
            thisViewModel.Roles = await GetUserRoles(user);
            userRolesViewModel.Add(thisViewModel);
        }

        return View(userRolesViewModel);
    }

    private async Task<List<string>> GetUserRoles(IdentityUser user)
    {
        return new List<string>(await _userManager.GetRolesAsync(user));
    }

    public async Task<IActionResult> Manage(string userId)
    {
        ViewBag.userId = userId;
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
            return View("NotFound");
        }

        ViewBag.UserName = user.UserName;
        var model = new List<ManageUserRolesViewModel>();

        foreach (var role in await _roleManager.Roles.ToListAsync())
        {
            var userRolesViewModel = new ManageUserRolesViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };

            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                userRolesViewModel.Selected = true;
            }
            else
            {
                userRolesViewModel.Selected = false;
            }

            model.Add(userRolesViewModel);
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return View();
        }

        var roles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, roles);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Cannot remove user existing roles");
            return View(model);
        }

        result = await _userManager.AddToRolesAsync(user,
            model.Where(x => x.Selected).Select(y => y.RoleName));

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Cannot add selected roles to user");
            return View(model);
        }
        EmailOuterService Outer = new EmailOuterService();

        return RedirectToAction("Index");
    }
}