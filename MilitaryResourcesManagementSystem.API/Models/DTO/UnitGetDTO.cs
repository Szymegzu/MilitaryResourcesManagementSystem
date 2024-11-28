namespace MilitaryResourcesManagementSystem.API.Models.DTO
{
    public class UnitGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreateDate { get; set; }
        public string Localization { get; set; }

        //public List<SoldierDTO> Soldiers { get; set; }
    }
}
