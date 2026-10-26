namespace HotelApp.Common.Contract
{
    public interface IValidationService
    {
        public Task<bool> IsValidIdAsync(int id);

        public Task<bool> ExistsAsync<T>(T? entity) where T : class;

        public Task<bool> HasAnyAsync<T>(IEnumerable<T>? collection);

        public Task<bool> IsNotNullOrWhiteSpaceAsync(string? value);
    }
}
