using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AutomovilController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Automovil automovil = new ML.Automovil();
            ML.Result result = BL.Automovil.GetAll();
            automovil.Automoviles = result.Objects;
            return View(automovil);
        }
        [HttpGet]
        public ActionResult Delete(int IdAutomovil)
        {
            ML.Result result = BL.Automovil.Delete(IdAutomovil);
            if (result.Correct)
            {
                ViewBag.Message = "Registro eliminado";
                return PartialView("Modal");

            }
            else
            {
                ViewBag.Message = "Error";
                return PartialView("Modal");
            }
        }
        public ActionResult Form(int? IdAutomovil)
        {
            ML.Automovil automovil = new ML.Automovil();
            if (IdAutomovil == null)
            {
                return View(automovil);
            }
            else
            {
                ML.Result result = BL.Automovil.GetById(IdAutomovil.Value);
                if (result.Correct)
                {
                    automovil = (ML.Automovil)result.Object;
                    return View(automovil);
                }
                else
                {
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Automovil automovil)
        {
            if (automovil.IdAutomovil == 0)
            {
                ML.Result result = new ML.Result();
                result = BL.Automovil.Add(automovil);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro agregado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Error al agregar";
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Automovil.Update(automovil);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro actualizado";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Error al actualizar";
                    return PartialView("Modal");
                }
            }

        }

    }
}
