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
