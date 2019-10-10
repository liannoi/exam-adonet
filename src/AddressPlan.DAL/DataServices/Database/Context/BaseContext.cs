using System.Data.Entity;
using System.Diagnostics;

namespace AddressPlan.DAL.DataServices.Database.Context
{
    public class BaseContext : DbContext
    {
        protected BaseContext(string databaseAlias) : base($"name={databaseAlias}")
        {
            Database.Log = l => Debug.WriteLine(l);
        }
    }
}
