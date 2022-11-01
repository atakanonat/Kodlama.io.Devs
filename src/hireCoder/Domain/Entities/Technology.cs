using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Technology()
        {
        }

        public Technology(int id, int programmingLanguageId, string name)
        {
            Id = id;
            Name = name;
            ProgrammingLanguageId = programmingLanguageId;
        }
    }
}