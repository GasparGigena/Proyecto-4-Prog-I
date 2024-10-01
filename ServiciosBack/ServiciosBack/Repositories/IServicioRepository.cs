using ServiciosBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosBack.Repositories
{
    public interface IServicioRepository
    {
        List<TServicio> GetAll();
        void Save (TServicio tServicio);
        void Delete(int id);
        List<TServicio> GetByFilters(int idServicio);
        TServicio? GetById(int id);
        void Update(TServicio servicio);

    }
}
