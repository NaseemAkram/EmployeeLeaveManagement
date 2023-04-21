using AutoMapper;
using EmployeeLeaveManagement.Contracts;
using EmployeeLeaveManagement.Models;
using EmployeeLeaveManagement.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagement.Controllers
{
    public class LeaveTypesController : Controller
    {

        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;
        public LeaveTypesController(ILeaveTypeRepository repo, IMapper maper)
        {
            _repo = repo;
            _mapper = maper;
        }
        // GET: LeaveTypesController
        public ActionResult Index()
        {

            var leavetype = _repo.FindAll().ToList();
            var result = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetype);
            return View(result);

        }

        // GET: LeaveTypesController/Details/5

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM leavetypevm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(leavetypevm);
                }
                var leavVm = _mapper.Map<LeaveType>(leavetypevm);
                leavVm.DateCreated = DateTime.Now;
                var issuccess = _repo.Create(leavVm);
                if (!issuccess)
                {
                    ModelState.AddModelError("", "something went wrong");
                    return View(leavetypevm);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "something went wrong");
                return View();
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }

            var result = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(result);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leavetype = _mapper.Map<LeaveType>(model);
                var issuccess = _repo.Update(leavetype);

                if (!issuccess)
                {
                    ModelState.AddModelError("", "Something went worng...");
                    return View(model);

                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Something went  worng please fix to properly run it successfully ");
                return View(model);
            }

        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_repo.IsExist(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeVM model)
        {
            try
            {
                var leavetype = _repo.FindById(id);
                if (leavetype == null)
                {
                    return NotFound();
                }
                var issuccess = _repo.Delete(leavetype);
                if (!issuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
