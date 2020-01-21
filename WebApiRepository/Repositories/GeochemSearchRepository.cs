using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiRepository.Models;
using WebApiRepository.Contracts;

namespace WebApiRepository.Repositories
{
    public class GeochemSearchRepository : IGeochemSearchRepository
    {
        private readonly string _connectionString;
        public GeochemSearchRepository(AppSettings appSettings)
        {
            _connectionString = appSettings.ConnectionString;
        }
        public Task<List<(string, string)>> GetLabMethodDetails(int labMethodId)
        {
            var controlsData = new List<(string, string)>();
            return Task.FromResult(controlsData); 
        }
    }
}
