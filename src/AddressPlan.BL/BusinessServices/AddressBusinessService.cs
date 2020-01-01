// Copyright 2020 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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

        public void Remove(int addressId)
        {
            DataServices.Unit.Addresses.Delete(addressId);
            DataServices.Unit.Commit();
        }

        #region Non contextual methods

        public IEnumerable<AddressDetailsBusinessObject> GetDetails()
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
