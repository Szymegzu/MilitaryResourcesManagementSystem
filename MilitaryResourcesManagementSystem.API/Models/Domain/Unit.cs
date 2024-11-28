namespace MilitaryResourcesManagementSystem.API.Models.Domain
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreateDate { get; set; }
        public string Localization { get; set; }

        public List<Soldier> Soldiers { get; set; }
    }
}
