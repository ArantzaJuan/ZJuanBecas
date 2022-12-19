using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class Beca
    {
        public static ML.Result GetallLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ZJuanBecaEntities context = new DL.ZJuanBecaEntities())
                {
                    var query = (from beca in context.Becas
                                 select new
                                 {
                                     beca.IdBeca,
                                     beca.Nombre,
                                     

                                 });
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Beca beca = new ML.Beca();

                            beca.IdBeca = obj.IdBeca;
                            beca.Nombre = obj.Nombre;
                            
                            result.Objects.Add(beca);
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        
    }
}
