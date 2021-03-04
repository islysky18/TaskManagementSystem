using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementDAL;

namespace TaskManagementRepository.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        private readonly Entities _context;
        private readonly DbSet<T> entity;

        public GenericRepository(Entities context)
        {
            _context = context;
            entity = _context.Set<T>();
        }

        public T Add()
        {
            throw new NotImplementedException();
        }

        public T Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return entity.AsEnumerable();
        }

        public T GetByQuoteID(int id)
        {
        //    Entities entity1 = new Entities();
        //    var entity2 = entity1.Quotes.FirstOrDefault(q => q.QuoteID == id);
            throw new NotImplementedException();
            //return entity.FirstOrDefault(x => x.QuoteID == id);
        }
    }
}
