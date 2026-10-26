using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp.Corе.DataTransferObjects.BookingsModels
{
    public class DeleteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = "Title must be between {2} and {1} characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(DescriptionMaxLength, ErrorMessage = "Description cannot exceed {1} characters.")]
        public string Description { get; set; } = string.Empty;
    }

}

