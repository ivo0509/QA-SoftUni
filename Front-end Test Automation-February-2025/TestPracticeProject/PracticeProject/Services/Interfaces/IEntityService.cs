using PracticeProject.Models;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Services.Interfaces
{
    public interface IEntityService
    {
        Task<List<DetailsEntityViewModel>> GetAll();
        Task<DetailsEntityViewModel> GetById(string id);
        Task Create(EntityViewModel entity);
    }
}
