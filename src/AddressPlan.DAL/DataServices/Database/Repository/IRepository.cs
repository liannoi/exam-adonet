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

using System.Collections.Generic;

namespace AddressPlan.DAL.DataServices.Database.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);

        void Delete(int id);

        TEntity GetEntity(int id);

        IEnumerable<TEntity> GetEntities(string query, params object[] parameters);

        List<TREntity> GetEntities<TREntity>(string query, params object[] parameters) where TREntity : class;

        List<TREntity> GetEntities<TREntity>(string query) where TREntity : class;

        void Insert(TEntity entity);

        void Update(TEntity entity);
    }
}
