using AddressPlan.DAL.DataServices.Database.Context;
using AddressPlan.DAL.DataServices.Database.Repository;
using AddressPlan.DAL.Entity;

namespace AddressPlan.DAL.DataServices.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseRepository<Address> _addresses;
        private BaseRepository<Street> _streets;
        private BaseRepository<Subdivision> _subdivisions;
        private readonly BaseContext _context;

        public UnitOfWork(BaseContext context)
        {
            _context = context;
        }

        public IRepository<Address> Addresses => _addresses ?? (_addresses = new BaseRepository<Address>(_context));

        public IRepository<Street> Streets => _streets ?? (_streets = new BaseRepository<Street>(_context));

        public IRepository<Subdivision> Subdivisions => _subdivisions ?? (_subdivisions = new BaseRepository<Subdivision>(_context));

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
