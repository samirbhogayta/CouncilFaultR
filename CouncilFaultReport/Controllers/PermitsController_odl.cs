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
    public class PermitsController_odl : Controller
    {
        private readonly IPermitRepository _dataAccessProvider = new PermitRepository();
        MongoDbContext objDB = new MongoDbContext();
        //public ActionResult Index()
        //{
        //    List<Permit> permit = objDB.Permit.
        //    return View();
        //}
        public async Task<ActionResult> Index()
        {
            IEnumerable<Permit> permits = await _dataAccessProvider.GetPermits();
            return View(permits);
        }

        public async Task<ActionResult> Details(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permit permit = await _dataAccessProvider.GetPermit(id);
            if(permit == null)
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
        public async Task<ActionResult> Create([Bind(Include ="")] Permit permit)
        {
            if(ModelState.IsValid)
            {
                await _dataAccessProvider.Add(permit);
                return RedirectToAction("Index");
            }
            return View(permit);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permit permit = await _dataAccessProvider.GetPermit(id);
            if(permit == null)
            {
                return HttpNotFound();
            }
            return View(permit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include ="")] Permit permit)
        {
            if(ModelState.IsValid)
            {
                await _dataAccessProvider.Update(permit);
                return RedirectToAction("Index");
            }
            return View(permit);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permit permit = await _dataAccessProvider.GetPermit(id);
            if(permit == null)
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
        //private CouncilFaultReportContext db = new CouncilFaultReportContext();

        //// GET: Permits
        //public ActionResult Index()
        //{
        //    return View(db.Permits.ToList());
        //}

        //// GET: Permits/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Permit permit = db.Permits.Find(id);
        //    if (permit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(permit);
        //}

        //// GET: Permits/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Permits/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,permit_number,customer_id,permit_valid_from,permit_valid_until,permit_issue_date,permit_cancel_date,name_title,first_name,last_name,email,postcode,organisation_or_charity,property_name_or_number,address_line,street_name,town,zone,country,telephone,authorisation_status,authorisation_status_note,is_tnc_accepted,permit_type,extra,address_id,amount,year,permit_period_id,vrn,make,model,color,cc,co2,tier,payment_amount,payment_type,payment_date,payment_cheque_number,payment_cheque_short_code,payment_cheque_cc_name,payment_bacs_payment_ref,payment_cc_payment_last_4_digit,payment_card_expiry_date,payment_cc_payment_ref_number,payment_postal_order_number,payment_page_note,no_of_times_change_of_registration_done,no_of_times_change_of_courtesy_car_done,is_permit,is_renewed,refund_amount,refund_type,refund_date,refund_cheque_number,refund_cheque_short_code,refund_cheque_cc_name,refund_bacs_payment_ref,refund_cc_payment_last_4_digit,refund_card_expiry_date,refund_cc_payment_ref_number,refund_postal_order_number,refund_page_note,created_at,updated_at,created_by,updated_by")] Permit permit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Permits.Add(permit);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(permit);
        //}

        //// GET: Permits/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Permit permit = db.Permits.Find(id);
        //    if (permit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(permit);
        //}

        //// POST: Permits/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,permit_number,customer_id,permit_valid_from,permit_valid_until,permit_issue_date,permit_cancel_date,name_title,first_name,last_name,email,postcode,organisation_or_charity,property_name_or_number,address_line,street_name,town,zone,country,telephone,authorisation_status,authorisation_status_note,is_tnc_accepted,permit_type,extra,address_id,amount,year,permit_period_id,vrn,make,model,color,cc,co2,tier,payment_amount,payment_type,payment_date,payment_cheque_number,payment_cheque_short_code,payment_cheque_cc_name,payment_bacs_payment_ref,payment_cc_payment_last_4_digit,payment_card_expiry_date,payment_cc_payment_ref_number,payment_postal_order_number,payment_page_note,no_of_times_change_of_registration_done,no_of_times_change_of_courtesy_car_done,is_permit,is_renewed,refund_amount,refund_type,refund_date,refund_cheque_number,refund_cheque_short_code,refund_cheque_cc_name,refund_bacs_payment_ref,refund_cc_payment_last_4_digit,refund_card_expiry_date,refund_cc_payment_ref_number,refund_postal_order_number,refund_page_note,created_at,updated_at,created_by,updated_by")] Permit permit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(permit).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(permit);
        //}

        //// GET: Permits/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Permit permit = db.Permits.Find(id);
        //    if (permit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(permit);
        //}

        //// POST: Permits/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Permit permit = db.Permits.Find(id);
        //    db.Permits.Remove(permit);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
