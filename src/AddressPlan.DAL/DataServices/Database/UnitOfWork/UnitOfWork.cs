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

        public BaseContext Context { get; set; }

        public UnitOfWork(BaseContext context)
        {
            Context = context;
        }

        public IRepository<Address> Addresses => _addresses ?? (_addresses = new BaseRepository<Address>(Context));

        public IRepository<Street> Streets => _streets ?? (_streets = new BaseRepository<Street>(Context));

        public IRepository<Subdivision> Subdivisions => _subdivisions ?? (_subdivisions = new BaseRepository<Subdivision>(Context));

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
