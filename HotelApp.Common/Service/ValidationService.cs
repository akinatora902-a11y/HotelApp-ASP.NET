using HotelApp.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Common.Service
{
    public class ValidationService : IValidationService
    {
        public Task<bool> IsValidIdAsync(int id)
        {
            return Task.FromResult(id > 0);
        }   

        public Task<bool> ExistsAsync<T>(T? entity) where T : class
        {
            return Task.FromResult(entity != null);
        }

        public Task<bool> HasAnyAsync<T>(IEnumerable<T>? collection)
        {
            return Task.FromResult(collection != null && collection.Any());
        }

        public Task<bool> IsNotNullOrWhiteSpaceAsync(string? value)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(value));
        }
    }
}
