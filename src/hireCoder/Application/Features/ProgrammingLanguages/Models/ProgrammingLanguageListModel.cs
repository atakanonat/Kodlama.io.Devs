using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel
    {
        public IList<ProgrammingLanguage> Items { get; set; }
    }
}