using System;
using System.Web.Mvc;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class BaseEditorController : BaseController
    {
        protected PartialViewResult Grid(IViewService<IBaseViewModel> service, string gridName, int? filter) =>
            PartialView($"Grids/_{gridName}", service.GetAll(filter));

        protected ActionResult Edit(IBaseEditModel model, Action prepare, string caller)
        {
            prepare?.Invoke();
            return View($"Edit/{caller}", model);
        }

        protected ActionResult Edit(Action edit, Action prepare, IBaseEditModel model, string caller, string redirectOnSuccess)
        {
            if (!ModelState.IsValid)
            {
                prepare?.Invoke();
                return View($"Edit/{caller}", model);
            }

            edit();
            return RedirectToAction(redirectOnSuccess);
        }

        protected ActionResult Delete(IEditService<IBaseEditModel> service, int id, string redirect)
        {
            service.Delete(id);
            return RedirectToAction(redirect);
        }
    }
}