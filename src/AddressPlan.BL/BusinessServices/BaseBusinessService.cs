using AddressPlan.DAL.DataServices;

namespace AddressPlan.BL.BusinessServices
{
    public abstract class BaseBusinessService
    {
        public BaseBusinessService(bool isMock)
        {
            DataServices.Initialize(isMock);
        }
    }
}
