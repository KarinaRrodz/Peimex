using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL 
{
    public class Usuario 
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Usuarios.FromSqlRaw("GetAllUsuario").ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.Apellido = obj.Apellido;
                            usuario.Username = obj.Username;
                            usuario.Contrasena = obj.Contrasena;

                            usuario.Automovil = new ML.Automovil();
                            usuario.Automovil.IdAutomovil = obj.IdAutomovil.Value;
                            usuario.Automovil.Placa = obj.Placa;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"GetByIdUsuario {IdUsuario}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.Apellido = query.Apellido;
                        usuario.Username = query.Username;
                        usuario.Contrasena = query.Contrasena;

                        usuario.Automovil = new ML.Automovil();
                        usuario.Automovil.IdAutomovil = query.IdAutomovil.Value;
                        usuario.Automovil.Placa = query.Placa;

                        result.Object= usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByUsername(string Username)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"GetByUsername {Username}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.Apellido = query.Apellido;
                        usuario.Username = query.Username;
                        usuario.Contrasena = query.Contrasena;

                        usuario.Automovil = new ML.Automovil();
                        usuario.Automovil.IdAutomovil = query.IdAutomovil.Value;
                        result.Object = usuario; //boxing

                    }

                    result.Correct = true;

                }

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddUsuario '{usuario.Nombre}','{usuario.Apellido}','{usuario.Username}','{usuario.Contrasena}',{usuario.Automovil.IdAutomovil}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateUsuario {usuario.IdUsuario},'{usuario.Nombre}','{usuario.Apellido}','{usuario.Username}','{usuario.Contrasena}',{usuario.Automovil.IdAutomovil}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeleteUsuario {IdUsuario}");
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
