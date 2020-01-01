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
