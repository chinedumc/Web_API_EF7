using System.ComponentModel.DataAnnotations;

namespace webAPI_EF.DTOs
{
    public class GenreCreationDTO
    {
        [StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;
    }
}
