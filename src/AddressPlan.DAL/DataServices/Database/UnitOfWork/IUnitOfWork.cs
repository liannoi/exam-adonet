using AddressPlan.DAL.DataServices.Database.Repository;
using AddressPlan.DAL.Entity;

namespace AddressPlan.DAL.DataServices.Database.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Address> Addresses { get; }

        IRepository<Street> Streets { get; }

        IRepository<Subdivision> Subdivisions { get; }

        void Commit();
    }
}
