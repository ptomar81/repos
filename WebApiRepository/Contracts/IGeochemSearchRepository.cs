using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace WebApiRepository.Contracts
{
   public interface IGeochemSearchRepository
    {
        Task<List<(string, string)>> GetLabMethodDetails(int labMethodId);

    }
}
