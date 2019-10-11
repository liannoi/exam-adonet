// Copyright 2019 Maksym Liannoi
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

using AddressPlan.DAL.DataServices.Database.Context;
using AddressPlan.DAL.DataServices.Database.Repository;
using AddressPlan.DAL.Entity;

namespace AddressPlan.DAL.DataServices.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseRepository<Address> _addresses;
        private BaseRepository<Street> _streets;
        private BaseRepository<Subdivision> _subdivisions;
        private readonly BaseContext _context;

        public UnitOfWork(BaseContext context)
        {
            _context = context;
        }

        public IRepository<Address> Addresses => _addresses ?? (_addresses = new BaseRepository<Address>(_context));

        public IRepository<Street> Streets => _streets ?? (_streets = new BaseRepository<Street>(_context));

        public IRepository<Subdivision> Subdivisions => _subdivisions ?? (_subdivisions = new BaseRepository<Subdivision>(_context));

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
