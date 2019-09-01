using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Core.Data;
using University.Core.Infrastructure;

namespace University.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly UniversityContext _context;

        private DbSet<TEntity> _entities;


        public EfRepository(UniversityContext context)
        {
            _context = context;
        }


        public async Task<TEntity> GetById(object id)
        {
            return await Entities.FindAsync(id);
        }

        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

    }
}
