using NoteBook.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteBook.Web.Controllers
{
    public class DefaultController : Controller
    {
        private IRepository mRepository;
        public DefaultController(IRepository _projectRepository)
        {
            mRepository = _projectRepository;
        }

        // GET: Default
        public ViewResult Index()
        {
            //var x = mRepository.States;
            //var y = mRepository.Orders.Count();

            //var x1 = mRepository.Orders;
            //var y1 = mRepository.Orders.Count();
            //return View(x);
            return View();
        }

        [HttpPost]
        public JsonResult DoAction()
        {
            dynamic result = new { };
            if (Request["action"] != null)
            {
                String actionString = Request["action"];
                switch (actionString)
                {
                    case "test-param":
                        {
                            if (Request["state-id"] != null)
                            {
                                try
                                {
                                    result =
                                        mRepository.States.ToArray();
                                }
                                catch (Exception ex)
                                {

                                    result = new { error = ex.Message };
                                }
                            }
                            break;
                        }
                    case "orders":
                        {
                            try
                            {
                                result =
                                    mRepository.Orders.ToArray();
                            }
                            catch (Exception ex)
                            {

                                result = new { error = ex.Message };
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            return Json(result);
        }
    }
}