using AddressPlan.BL.BusinessObjects;
using AddressPlan.DAL.DataServices;
using System.Collections.Generic;

namespace AddressPlan.BL.BusinessServices
{
    public sealed class SubdivisionBusinessService : BaseBusinessService
    {
        public SubdivisionBusinessService() : base(false)
        {
        }

        public static IEnumerable<SubdivisionBusinessObject> GetSubdivisions(bool wantNull)
        {
            const string query = @"SELECT *
                                   FROM dbo.Subdivision";

            List<SubdivisionBusinessObject> collection = DataServices.Unit.Subdivisions.GetEntities<SubdivisionBusinessObject>(query);

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
            collection.AddRange(DataServices.Unit.Subdivisions.GetEntities<SubdivisionBusinessObject>(query));
            return collection;
        }
    }
}
