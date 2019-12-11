using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CouncilFaultReport.Models;

namespace CouncilFaultReport.Controllers
{
    public class PermitsController : Controller
    {
        //MongoDbContext db = new MongoDbContext();
        private readonly IPermitRepository _dataAccessProvider = new PermitRepository();        
        public async Task<ActionResult> Index()
        {
            IEnumerable<Permit> permits = await _dataAccessProvider.GetPermits();
            return View(permits);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permit permit = await _dataAccessProvider.GetPermit(id);
            if (permit == null)
            {
                return HttpNotFound();
            }
            return View(permit);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Address,Gender,Company,Designation")] Permit permit)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Add(permit);
                return RedirectToAction("Index");
            }

            return View(permit);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permit permit = await _dataAccessProvider.GetPermit(id);
            if (permit == null)
            {
                return HttpNotFound();
            }
            return View(permit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address,Gender,Company,Designation")] Permit permit)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Update(permit);
                return RedirectToAction("Index");
            }
            return View(permit);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Permit permit = await _dataAccessProvider.GetPermit(id);
            if (permit == null)
            {
                return HttpNotFound();
            }
            return View(permit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _dataAccessProvider.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
