namespace MilitaryResourcesManagementSystem.API.Models.DTO
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreateDate { get; set; }
        public string Localization { get; set; }

        public SoldierDTO Soldiers { get; set; }
    }
}
