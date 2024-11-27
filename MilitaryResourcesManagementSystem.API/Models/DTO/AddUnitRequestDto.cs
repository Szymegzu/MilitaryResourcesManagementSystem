namespace MilitaryResourcesManagementSystem.API.Models.DTO
{
    public class AddUnitRequestDto
    {
        public string Name { get; set; }
        public DateOnly CreateDate { get; set; }
        public string Localization { get; set; }
    }
}
