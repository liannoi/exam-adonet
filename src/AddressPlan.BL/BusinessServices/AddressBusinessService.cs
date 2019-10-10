using AddressPlan.BL.BusinessObjects;
using AddressPlan.DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AddressPlan.BL.BusinessServices
{
    public sealed class AddressBusinessService : BaseBusinessService
    {
        public AddressBusinessService() : base(false)
        {
        }

        public IEnumerable<AddressBusinessObject> GetAddresses(int streetId, int subdivisionId)
        {
            const string query = "EXEC dbo.GetData @StreetId, @SubdivisionId";

            SqlParameter pStreetId = streetId == 0
                ? new SqlParameter("@StreetId", DBNull.Value)
                : new SqlParameter("@StreetId", streetId);

            SqlParameter pSubdivisionId = subdivisionId == 0
                ? new SqlParameter("@SubdivisionId", DBNull.Value)
                : new SqlParameter("@SubdivisionId", subdivisionId);

            return DataServices.Unit.Streets.GetEntities<AddressBusinessObject>(query, pStreetId, pSubdivisionId);
        }

        public void Remove(int addressId)
        {
            DataServices.Unit.Addresses.Delete(addressId);
            DataServices.Unit.Commit();
        }
    }
}
