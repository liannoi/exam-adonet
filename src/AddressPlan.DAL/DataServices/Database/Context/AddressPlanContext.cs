namespace AddressPlan.DAL.DataServices.Database.Context
{
    using AddressPlan.DAL.Entity;
    using System.Data.Entity;

    public partial class AddressPlanContext : BaseContext
    {
        public AddressPlanContext() : base("AddressPlanContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Street> Streets { get; set; }

        public virtual DbSet<Subdivision> Subdivisions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Do nothing.
        }
    }
}
