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
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AddressPlan.DAL.DataServices.Database.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BaseContext _context;
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(BaseContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entity = _entities.Find(id);
            Delete(entity);
        }

        public virtual IEnumerable<TEntity> GetEntities(string query, params object[] parameters)
        {
            return _entities.SqlQuery(query, parameters).ToList();
        }

        public virtual List<TREntity> GetEntities<TREntity>(string query, params object[] parameters) where TREntity : class
        {
            return _context.Database.SqlQuery<TREntity>(query, parameters).ToList();
        }

        public virtual List<TREntity> GetEntities<TREntity>(string query) where TREntity : class
        {
            return _context.Database.SqlQuery<TREntity>(query).ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return _entities.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.AddOrUpdate(entity);
        }
    }
}
