using Demo.MyModels;
using System.Collections.Generic;

namespace Demo.Services.Interfaces
{
    public interface ICarrierService : IGeneralService<Carrier>
    {
        int Import(IList<Carrier> carriers);
    }
}
