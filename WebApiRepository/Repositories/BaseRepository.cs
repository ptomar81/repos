using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiRepository.Contracts;
using WebApiRepository.Models;
namespace WebApiRepository.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly string _connectionString;
        public BaseRepository(AppSettings appSettings)
        {
            _connectionString = appSettings.ConnectionString;
        }

        public Task<List<(string, string)>> GetControlData(string controlName, string userEmail)
        {
            var controlsData = new List<(string, string)>();
            return Task.FromResult(controlsData);
        }
    }
}
