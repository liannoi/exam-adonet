namespace AddressPlan.BL.BusinessObjects
{
    public class StreetBusinessObject
    {
        public int AddressId { get; set; }

        public string StreetName { get; set; }

        public string House { get; set; }

        public string SubdivisionName { get; set; }

        public override string ToString()
        {
            return $@"{AddressId}, {StreetName}, {House}, {SubdivisionName}";
        }
    }
}
