using AddressPlan.DAL.DataServices;

namespace AddressPlan.BL.BusinessServices
{
    public abstract class BaseBusinessService
    {
        protected BaseBusinessService(bool isMock)
        {
            DataServices.Initialize(isMock);
        }
    }
}
