using ServiciosBack.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosBack.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private ServiciosDbContext _context;

        public ServicioRepository(ServiciosDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)  
        {
            var servicio = GetById(id);
            _context.TServicios.Remove(servicio);
            _context.SaveChanges();
        }

        public List<TServicio> GetAll()
        {
            return _context.TServicios.ToList();
        }

        public List<TServicio> GetByFilters(int idServicio)
        {
            return _context.TServicios.Where(x => x.Id == idServicio).ToList();
        }

        public TServicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }

        public void Save(TServicio tServicio)
        {
            _context.TServicios.Add(tServicio);
            _context.SaveChanges();
        }

        public void Update(TServicio servicio)
        {
            _context.Update(servicio);
            _context.SaveChanges();
        }
    }
}
