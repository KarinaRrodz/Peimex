using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.Delete(IdUsuario);
            if (result.Correct = true)
            {
                ViewBag.Message = "Registro eliminado";
                return PartialView("ModalU");
            }
            else
            {
                ViewBag.Message = "Error";
                return PartialView("ModalU");
            }
        }
        public ActionResult Form(int IdUsuario)
        {
            
            ML.Result resultAutomovil = BL.Automovil.GetAll();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Automovil= new ML.Automovil();

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
                ML.Result result = BL.Usuario.GetById(IdUsuario);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Automovil.Automoviles = resultAutomovil.Objects;
                    return View(usuario);
                }
                else
                {
                    return View(null);
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                ML.Result result = new ML.Result();
                result = BL.Usuario.Add(usuario);
                if (result.Correct = true)
                {
                    ViewBag.Message = "Registro agregado";
                    return PartialView("ModalU");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return PartialView("ModalU");
                }
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Usuario.Update(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Registro actualizado";
                    return PartialView("ModalU");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return PartialView("ModalU");
                }
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Contrasena)
        {
            ML.Result result = BL.Usuario.GetByUsername(Username);
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if (Contrasena == usuario.Contrasena)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "La contraseña no coincide";
                    return PartialView("LoginModal");
                }
            }
            else
            {
                ViewBag.Messge = "El usuario no existe";
                return PartialView("LoginModal");
            }
        }

    }
}
