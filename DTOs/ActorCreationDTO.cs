using System.ComponentModel.DataAnnotations;

namespace webAPI_EF.DTOs
{
    public class ActorCreationDTO
    {
        [StringLength(150)]
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public double Fortune { get; set; }

    }
}
