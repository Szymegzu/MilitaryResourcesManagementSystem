using MilitaryResourcesManagementSystem.API.Models.Domain;

namespace MilitaryResourcesManagementSystem.API.Models.DTO
{
    public class SoldierDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string? Nickname { get; set; }
        public int Age { get; set; }
        public string Rank { get; set; }
        //public int UnitId { get; set; }

        //public UnitDTO Unit { get; set; }
    }
}
