using Application.Features.Technologies.DTOs;

namespace Application.Features.Technologies.Models
{
    public class TechnologyListModel
    {
        public IList<TechnologyListDTO> items { get; set; }
    }
}