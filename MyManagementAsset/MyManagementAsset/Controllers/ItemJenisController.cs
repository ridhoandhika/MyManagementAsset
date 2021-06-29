using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyManagementAsset.Context;
using MyManagementAsset.Models;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace MyManagementAsset.Controllers
{
    public class ItemJenisController : Controller
    {
        readonly ItemJenis_DAL dbContext = new ItemJenis_DAL();
        // GET: ItemJenisController
        //public ActionResult Index()
        //{
        //    List<ItemJenis> ItemJenisList = dbContext.GetAllItemJenis().ToList();
        //    return View(ItemJenisList);
        //}
        public IActionResult Index(int? page)//Add page parameter
        {
            var pageNumber = page ?? 1; // if no page is specified, default to the first page (1)
            int pageSize = 5; // Get 25 students for each requested page.
            var onePageOfItemJenis = dbContext.GetAllItemJenis().ToPagedList(pageNumber, pageSize);
            return View(onePageOfItemJenis); // Send 25 students to the page.
        }

        // GET: ItemJenisController/Details/5
        public ActionResult Details(string jns_kode)
        {
            if (jns_kode == "" )
            {
                return NotFound();
            }
            ItemJenis itemJenis = dbContext.GetItemJenisById(jns_kode);
            if (itemJenis == null)
            {
                return NotFound();
            }
            return View(itemJenis);
        }

        // GET: ItemJenisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemJenisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] ItemJenis itemjenis)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateItemJenis(itemjenis);
                    return RedirectToAction("Index");
                }
                return View(itemjenis);
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemJenisController/Edit/5
        public ActionResult Edit(string jns_kode)
        {
            if (jns_kode == "")
            {
                return NotFound();
            }
            ItemJenis itemjenis = dbContext.GetItemJenisById(jns_kode);
            if (itemjenis == null)
            {
                return NotFound();
            }
            return View(itemjenis);
        }

        // POST: ItemJenisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string jns_kode, [Bind] ItemJenis itemjenis)
        {
            try
            {
                if (jns_kode == "")
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbContext.UpdateItemJenis(itemjenis);
                    return RedirectToAction("Index");
                }
                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemJenisController/Delete/5
        public ActionResult Delete(string jns_kode)
        {
            if (jns_kode == "")
            {
                return NotFound();
            }
            ItemJenis itemjenis = dbContext.GetItemJenisById(jns_kode);
            if (itemjenis == null)
            {
                return NotFound();
            }
            return View(itemjenis);
        }

        // POST: ItemJenisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string jns_kode, [Bind] ItemJenis itemjenis)
        {
            try
            {
                if (jns_kode == "")
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbContext.DeleteItemJenis(itemjenis);

                    return RedirectToAction("Index");
                }
                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }
    }
}
