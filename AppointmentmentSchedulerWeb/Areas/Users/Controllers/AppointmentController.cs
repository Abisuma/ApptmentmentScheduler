using ApptmentmentScheduler.DataAccessLayer.Repository.IRepository;
using ApptmentmentScheduler.Models.Models;
using ApptmentmentScheduler.Models.Models.ViewModels;
using ApptmentmentScheduler.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentmentSchedulerWeb.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = SD.Role_Users)]
    
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
       
        public AppointmentController(IUnitOfWork unitOfWork, Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
           
        }

        public ActionResult Index()
        {
            try
            {
                var user = _userManager.GetUserAsync(User).Result;

                if (user != null)
                {
                    //getting the user id
                    string userID = user.Id;
                    
                    List<Appointment> appointmentList = _unitOfWork.Appoint.GetAllApp(userID).ToList();

                    return View(appointmentList);
                }

            }
            catch (Exception)
            {
                TempData["error"] = "User not found";
            }
                return View();
        }


   
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppointmentController1/UpSert
        public ActionResult UpSert(int? id)
        {
            AppointViewModel vm = new()
            {
                Appointment = new Appointment()
            };

            //create

            if (id == null || id == 0)
            {
                return View(vm);
            }

            //edit
            else
            {
                vm.Appointment = _unitOfWork.Appoint.GetAApp(u => u.Id == id);
                return View(vm);

            }


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(AppointViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var userIdentity = _userManager.GetUserId(User);
                obj.Appointment.UserId = userIdentity;
               
                    if (obj.Appointment.Id == 0 && obj.Appointment.UserId != null)
                    {
                        _unitOfWork.Appoint.CreateApp(obj.Appointment);
                    }
                    else
                    {
                        _unitOfWork.Appoint.Update(obj.Appointment);
                    }
                   
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                
            }

            return View(obj);
        }



        // GET: AppointmentController1/Delete/5

        
        public ActionResult Delete(int id)
        {
            if (id != null || id != 0)
            {
                var appToBeDeleted = _unitOfWork.Appoint.GetAApp(u => u.Id == id);
                return View(appToBeDeleted);

            }

            return NotFound();
        }

        // POST: AppointmentController1/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteAppointment(int? id)
        {

            if (id != null || id != 0)
            {
                var obj = _unitOfWork.Appoint.GetAApp(u => u.Id == id);
                if (obj != null)
                {
                    _unitOfWork.Appoint.DeleteApp(obj);
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }

            }

            return View();

        }


       

    }

}