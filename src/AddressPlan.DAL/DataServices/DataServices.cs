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
using AddressPlan.DAL.DataServices.Database.UnitOfWork;
using System;

namespace AddressPlan.DAL.DataServices
{
    public static class DataServices
    {
        public static UnitOfWork Unit { get; set; }

        public static void Initialize(bool isMock)
        {
            if (isMock)
            {
                throw new NotImplementedException("Mock Data Services not implemented.");
            }
            else
            {
                Unit = new UnitOfWork(new AddressPlanContext());
            }
        }
    }
}
