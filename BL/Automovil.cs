using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Automovil
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Automovils.FromSqlRaw("GetAllAutomovil").ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Automovil automovil = new ML.Automovil();
                            automovil.IdAutomovil = obj.IdAutomovil;
                            automovil.Placa = obj.Placa;

                            result.Objects.Add(automovil);
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
        public static ML.Result GetById(int IdAutomovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Automovils.FromSqlRaw($"GetByIdAutomovil {IdAutomovil}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Automovil automovil = new ML.Automovil();
                        automovil.IdAutomovil = query.IdAutomovil;
                        automovil.Placa = query.Placa;

                        result.Object = automovil;
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
        public static ML.Result Add(ML.Automovil automovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddAutomovil '{automovil.Placa}'");
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
        public static ML.Result Update(ML.Automovil automovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateAutomovil {automovil.IdAutomovil},'{automovil.Placa}'");
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
        public static ML.Result Delete(int IdAutomovil)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.PeimexContext context = new DL.PeimexContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"DeleteAutomovil {IdAutomovil}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
    }
}
