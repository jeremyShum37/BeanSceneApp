using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanSceneApp.Data;
using BeanSceneApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeanSceneApp.Controllers
{
    [Authorize(Roles = "Admin, Manager, Staff")]
    public class UsersController : Controller
    {
        private readonly BeanSceneAppContext _context;

        public UsersController(BeanSceneAppContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [Authorize(Roles = "Admin, Staff")]
        // GET: Users/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user, IFormFile Image)
        {
            //[Bind("UserId,FirstName,LastName,Email,Phone,Password,Image,Role")]
            User user1 = new User();
            user1.FirstName = user.FirstName;
            user1.LastName = user.LastName;
            user1.Email = user.Email;
            user1.Phone = user.Phone;
            user1.Password = user.Password;
            user1.Role = user.Role;

            if (Image != null && Image.Length > 0)
            {
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"));
                }
                // Check if the file already exists, upload it only if it doesn't exist
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                        ViewBag.Message = "File uploaded successfully.";
                    }
                }
                else
                {
                    ViewBag.Message = "File already exists. Please choose a different file.";
                }
                user1.Image = "/images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Add(user1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user, IFormFile Image)
        {
            //[Bind("UserId,FirstName,LastName,Email,Phone,Password,Image,Role")]
            User user1 = new User();
            if (id != user.UserId)
            {
                return NotFound();
            }
            else
            {
                user1.UserId = user.UserId;
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.Email = user.Email;
                user1.Phone = user.Phone;
                user1.Password = user.Password;
                user1.Role = user.Role;

                if (Image != null && Image.Length > 0)
                {
                    var fileName = Path.GetFileName(Image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"));
                    }
                    // Check if the file already exists, upload it only if it doesn't exist
                    if (!System.IO.File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Image.CopyToAsync(stream);
                            ViewBag.Message = "File uploaded successfully.";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "File already exists. Please choose a different file.";
                    }
                    user1.Image = "/images/" + fileName;
                }
            }
        
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user1.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user1);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
