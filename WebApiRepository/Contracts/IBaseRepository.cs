using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace WebApiRepository.Contracts
{
    public interface IBaseRepository
    {
        Task<List<(string, string)>> GetControlData(string controlName, string userName);

    }
}
