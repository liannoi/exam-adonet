using AddressPlan.BL.BusinessObjects;
using AddressPlan.DAL.DataServices;
using System.Collections.Generic;

namespace AddressPlan.BL.BusinessServices
{
    public sealed class StreetBusinessService : BaseBusinessService
    {
        public StreetBusinessService() : base(false)
        {
        }

        public IEnumerable<StreetBusinessObject> GetStreets(bool wantNull)
        {
            const string query = @"SELECT *
                                   FROM dbo.Street";

            List<StreetBusinessObject> collection = DataServices.Unit.Addresses.GetEntities<StreetBusinessObject>(query);

            if (!wantNull)
            {
                return collection;
            }

            collection = new List<StreetBusinessObject>
            {
                new StreetBusinessObject
                {
                    StreetId = 0,
                    StreetName = "Все улицы"
                }
            };
            collection.AddRange(DataServices.Unit.Addresses.GetEntities<StreetBusinessObject>(query));
            return collection;
        }
    }
}
