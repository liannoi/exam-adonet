using AddressPlan.BL.BusinessObjects;
using AddressPlan.DAL.DataServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AddressPlan.BL.BusinessServices
{
    public class AddressPlanBusinessService
    {
        public AddressPlanBusinessService()
        {
            DataServices.Initialize(false);
        }

        public IEnumerable<StreetBusinessObject> GetStreets(int streetId, int subdivisionId)
        {
            const string query = "EXEC dbo.GetData @StreetId, @SubdivisionId";

            SqlParameter pStreetId = streetId == 0
                ? new SqlParameter("@StreetId", DBNull.Value)
                : new SqlParameter("@StreetId", streetId);

            SqlParameter pSubdivisionId = subdivisionId == 0
                ? new SqlParameter("@SubdivisionId", DBNull.Value)
                : new SqlParameter("@SubdivisionId", subdivisionId);

            return DataServices.Unit.Streets.GetEntities<StreetBusinessObject>(query, pStreetId, pSubdivisionId);
        }

        public IEnumerable<SubdivisionBusinessObject> GetSubdivisions(bool wantNull)
        {
            const string query = @"SELECT *
                                   FROM dbo.Subdivision";

            List<SubdivisionBusinessObject> collection = DataServices.Unit.Subdivisions.Execute<SubdivisionBusinessObject>(query);

            if (!wantNull)
            {
                return collection;
            }

            collection = new List<SubdivisionBusinessObject>
            {
                new SubdivisionBusinessObject
                {
                    SubdivisionId = 0,
                    SubdivisionName = "Все подразделения"
                }
            };
            collection.AddRange(DataServices.Unit.Subdivisions.Execute<SubdivisionBusinessObject>(query));
            return collection;
        }

        public IEnumerable<StreetBusinessObject> GetStreets(bool wantNull)
        {
            const string query = @"SELECT *
                                   FROM dbo.Street";

            List<StreetBusinessObject> collection = DataServices.Unit.Addresses.Execute<StreetBusinessObject>(query);

            if (!wantNull)
            {
                return collection;
            }

            collection = new List<StreetBusinessObject>
            {
                new StreetBusinessObject
                {
                    AddressId = 0,
                    StreetName = "Все улицы"
                }
            };
            collection.AddRange(DataServices.Unit.Addresses.Execute<StreetBusinessObject>(query));
            return collection;
        }
    }
}
