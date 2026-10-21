using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Common.Contract
{
    public interface IValidationService 
    {
        public bool IsValidId(int id);

        public bool Exists<T>(T? entity) where T : class;

        public bool HasAny<T>(IEnumerable<T>? collection);

        public bool IsNotNullOrWhiteSpace(string? value);
    }
}
