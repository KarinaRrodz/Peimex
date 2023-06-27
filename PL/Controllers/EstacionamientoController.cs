using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EstacionamientoController : Controller
    {
        public ActionResult Form(int IdUsuario)
        {
            ML.Result resultAutomovil = BL.Automovil.GetAll();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Automovil = new ML.Automovil();
            if (resultAutomovil.Correct)
            {
                usuario.Automovil.Automoviles = resultAutomovil.Objects;
            }
            if (IdUsuario == 0)
            {
                return View(usuario);
            }
            else
            {
                return View(null);
            }
        }
    }
}
