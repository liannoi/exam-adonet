using AddressPlan.BL.BusinessObjects;
using AddressPlan.DAL.DataServices;
using AddressPlan.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AddressPlan.BL.BusinessServices
{
    public sealed class AddressBusinessService : BaseBusinessService
    {
        public AddressBusinessService() : base(false)
        {
        }

        public static IEnumerable<AddressBusinessObject> GetAddresses(int streetId, int subdivisionId)
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

        public void Update(AddressDetailsBusinessObject addressDetailsBusinessObject)
        {
            DataServices.Unit.Addresses.Update(new Address
            {
                AddressId = addressDetailsBusinessObject.AddressId,
                House = addressDetailsBusinessObject.HouseNumber,
                StreetId = addressDetailsBusinessObject.StreetId,
                SubdivisionId = addressDetailsBusinessObject.SubdivisionId
            });
            DataServices.Unit.Commit();
        }

        public void Add(AddressDetailsBusinessObject addressDetails)
        {
            DataServices.Unit.Addresses.Insert(new Address
            {
                AddressId = -1,
                House = addressDetails.HouseNumber,
                StreetId = addressDetails.StreetId,
                SubdivisionId = addressDetails.SubdivisionId
            });
            DataServices.Unit.Commit();
        }

        public static void Remove(int addressId)
        {
            DataServices.Unit.Addresses.Delete(addressId);
            DataServices.Unit.Commit();
        }

        #region Non contextual methods

        public static IEnumerable<AddressDetailsBusinessObject> GetDetails()
        {
            const string query = @"SELECT * FROM dbo.Address";

            return DataServices.Unit.Addresses.GetEntities<AddressDetailsBusinessObject>(query);
        }

        public AddressDetailsBusinessObject Find(int addressId)
        {
            return GetDetails().ToList().Find(d => d.AddressId == addressId);
        }

        #endregion
    }
}
