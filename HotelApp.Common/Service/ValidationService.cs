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
        public bool IsValidId(int id)
        {
            return id > 0;
        }

        public bool Exists<T>(T? entity) where T : class
        {
            return entity != null;
        }

        public bool HasAny<T>(IEnumerable<T>? collection)
        {
            return collection != null && collection.Any();
        }

        public bool IsNotNullOrWhiteSpace(string? value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
