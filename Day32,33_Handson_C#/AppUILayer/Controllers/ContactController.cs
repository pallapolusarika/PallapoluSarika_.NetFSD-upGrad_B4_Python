using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppUILayer.Controllers
{
    [Route("[controller]/[action]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        public IActionResult AddContact()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(contact);
            }

            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            LoadDropdowns();
            return View(contact);
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(contact);
            }

            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult GetContactById(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(_repo.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repo.GetDepartments(), "DepartmentId", "DepartmentName");
        }
    }
}
