using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Exam2.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Exam2.Controllers
{
    [Route("/home/")]
    public class HomeController : Controller
    {
        private Exam2Context dbContext;
        public HomeController(
            Exam2Context context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                if (dbContext.users.Any(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId")))
                {
                    ViewBag.User = dbContext.users.FirstOrDefault(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId"));
                    List<Activities> allActivities = dbContext.activities.Include(a => a.Creator).Include(a => a.Participants).ThenInclude(p => p.User).ToList();
                    return View(allActivities);
                }
                return RedirectToAction("Logout", "LoginReg");
            }
            return RedirectToAction("LoginReg", "LoginReg");
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                if (dbContext.users.Any(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId")))
                {
                    return View();
                }
                return RedirectToAction("Logout", "LoginReg");
            }
            return RedirectToAction("LoginReg", "LoginReg");
        }
        public IActionResult Create(NewActivity model)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                if (dbContext.users.Any(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId")))
                {
                    if (ModelState.IsValid)
                    {
                        if (DateTime.Compare(model.Date.Date.Add(model.Time.TimeOfDay), DateTime.Now) > 0)
                        {
                            if (!dbContext.activities.Any(a => a.Title == model.Title && a.CreatorId == (int)HttpContext.Session.GetInt32("UserID") && a.DateTime == model.Date.Date.Add(model.Time.TimeOfDay)))
                            {
                                Activities new_activity = new Activities
                                {
                                    Title = model.Title,
                                    DateTime = model.Date.Date.Add(model.Time.TimeOfDay),
                                    Duration = model.Duration,
                                    DurationUnit = model.DurationUnit,
                                    Description = model.Description,
                                    CreatorId = (int)HttpContext.Session.GetInt32("UserId"),
                                };
                                dbContext.Add(new_activity);
                                dbContext.SaveChanges();
                                int activityid = dbContext.activities.FirstOrDefault(a => a.Title == model.Title).ActivitiesId;
                                return RedirectToAction("Activity", new {activity_id = activityid});
                            }
                            ModelState.AddModelError("Title", "This activity already exists");
                            }
                        ModelState.AddModelError("Date", "This date and time have already passed.");
                    }
                    return View("New", model);
                }
                return RedirectToAction("Logout", "LoginReg");
            }
            return RedirectToAction("LoginReg", "LoginReg");
        }
        [HttpGet("activity/{activity_id}")]
        public IActionResult Activity(int activity_id)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                if (dbContext.users.Any(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId")))
                {
                    Activities activity = dbContext.activities.Include(a => a.Creator).Include(a => a.Participants).ThenInclude(p => p.User).FirstOrDefault(a => a.ActivitiesId == activity_id);
                    ViewBag.User = dbContext.users.FirstOrDefault(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId"));
                    return View(activity);
                }
                return RedirectToAction("Logout", "LoginReg");
            }
            return RedirectToAction("LoginReg", "LoginReg");
        }
        [HttpGet("participating/{activity_id}")]
        public IActionResult Participating(int activity_id)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                if (dbContext.users.Any(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId")))
                {
                    if(dbContext.activities.Any(a => a.ActivitiesId == activity_id))
                    {
                        if(dbContext.activities.FirstOrDefault(a => a.ActivitiesId == activity_id).CreatorId != (int)HttpContext.Session.GetInt32("UserId"))
                        {
                            if(!dbContext.participants.Any(p => p.ActivitiesId == activity_id && p.UsersId == (int)HttpContext.Session.GetInt32("UserId")))
                            {
                                Users UserwithSchedule = dbContext.users.Include(u => u.Participating).ThenInclude(p => p.Activity).FirstOrDefault(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId"));
                                Activities newactivity = dbContext.activities.FirstOrDefault(a => a.ActivitiesId == activity_id);
                                DateTime newactivity_starttime = newactivity.DateTime;
                                DateTime newactivity_endtime = newactivity_starttime;
                                if (newactivity.DurationUnit == "Hours")
                                {
                                    newactivity_endtime = newactivity_starttime.AddHours(newactivity.Duration);
                                }
                                else if(newactivity.DurationUnit == "Minutes")
                                {
                                    newactivity_endtime = newactivity_starttime.AddMinutes(newactivity.Duration);
                                }
                                else
                                {
                                    newactivity_endtime = newactivity_starttime.AddDays(newactivity.Duration);
                                }
                                bool isTrue = true;
                                foreach(Participants part in UserwithSchedule.Participating)
                                {
                                    DateTime activitystarttime = part.Activity.DateTime;
                                    DateTime activityendtime = activitystarttime;
                                    if (part.Activity.DurationUnit == "Hours")
                                    {
                                        activityendtime = activitystarttime.AddHours(part.Activity.Duration);
                                    }
                                    else if(part.Activity.DurationUnit == "Minutes")
                                    {
                                        activityendtime = activitystarttime.AddMinutes(part.Activity.Duration);
                                    }
                                    else
                                    {
                                        activityendtime = activitystarttime.AddDays(part.Activity.Duration);
                                    }
                                    if ((DateTime.Compare(newactivity_starttime, activitystarttime) < 0 && DateTime.Compare(newactivity_endtime, activitystarttime) > 0) || (DateTime.Compare(newactivity_starttime,activitystarttime) > 0 && DateTime.Compare(newactivity_starttime,activityendtime) < 0) || DateTime.Compare(newactivity_starttime, activitystarttime) == 0 || DateTime.Compare(newactivity_endtime, activityendtime) == 0)
                                    {
                                        isTrue = false;
                                    }
                                }
                                if (isTrue == true)
                                {
                                    Participants new_part = new Participants
                                    {
                                        ActivitiesId = activity_id,
                                        UsersId = (int)HttpContext.Session.GetInt32("UserId"),
                                    };
                                    dbContext.participants.Add(new_part);
                                    dbContext.SaveChanges();
                                }
                                else
                                {
                                    TempData["Error"] = "You could not join this activity because you are already busy at that time";
                                }
                            }
                        }
                    }
                    return RedirectToAction("Dashboard");
                }
                return RedirectToAction("Logout", "LoginReg");
            }
            return RedirectToAction("LoginReg", "LoginReg");
        }
        [HttpGet("notparticipating/{activity_id}")]
        public IActionResult NotParticipating(int activity_id)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                if (dbContext.users.Any(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId")))
                {
                    Participants part = dbContext.participants.FirstOrDefault(p => p.ActivitiesId == activity_id && p.UsersId == (int)HttpContext.Session.GetInt32("UserId"));
                    if(part != null)
                    {
                        dbContext.participants.Remove(part);
                        dbContext.SaveChanges();
                    }
                    return RedirectToAction("Dashboard");
                }
                return RedirectToAction("Logout", "LoginReg");
            }
            return RedirectToAction("LoginReg", "LoginReg");
        }
        [HttpGet("delete/{activity_id}")]
        public IActionResult Delete(int activity_id)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                if (dbContext.users.Any(u => u.UsersId == (int)HttpContext.Session.GetInt32("UserId")))
                {
                    Activities activity = dbContext.activities.FirstOrDefault(a => a.ActivitiesId == activity_id);
                    if (activity.CreatorId == (int)HttpContext.Session.GetInt32("UserId"))
                    {
                        dbContext.activities.Remove(activity);
                        dbContext.SaveChanges();
                    }
                    return RedirectToAction("Dashboard");
                }
                return RedirectToAction("Logout", "LoginReg");
            }
            return RedirectToAction("LoginReg", "LoginReg");
        }
    }
}