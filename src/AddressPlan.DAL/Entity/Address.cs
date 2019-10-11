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

namespace AddressPlan.DAL.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Address")]
    public partial class Address
    {
        public int AddressId { get; set; }

        public int StreetId { get; set; }

        public int SubdivisionId { get; set; }

        [Required]
        [StringLength(12)]
        public string House { get; set; }

        [StringLength(24)]
        public string Serial { get; set; }

        public int? СountFloor { get; set; }

        public int? СountEntrance { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public virtual Street Street { get; set; }

        public virtual Subdivision Subdivision { get; set; }
    }
}
