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
