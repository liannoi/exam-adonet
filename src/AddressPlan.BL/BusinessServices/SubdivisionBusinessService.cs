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
using System.Collections.Generic;

namespace AddressPlan.BL.BusinessServices
{
    public sealed class SubdivisionBusinessService : BaseBusinessService
    {
        public SubdivisionBusinessService() : base(false)
        {
        }

        public IEnumerable<SubdivisionBusinessObject> GetSubdivisions(bool wantNull)
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
