using Microsoft.EntityFrameworkCore;
using PracticeProject.DbContext;
using PracticeProject.DbContext.DataModels;
using PracticeProject.Models;
using PracticeProject.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace PracticeProject.Services
{
    public class EntityService : IEntityService
    {
        private readonly TestPractiveDb context;
        public EntityService(TestPractiveDb context)
        {
            this.context = context;
        }
        public async Task  Create(EntityViewModel entity)
        {
            var dbEntity = new TestEntityModel()
            {
                Name = entity.Name,
                Author = entity.Author,
                Count = entity.Count,
                Description = entity.Description,
                Status = entity.Status
            };

            await context.AddAsync(dbEntity);
            await context.SaveChangesAsync();
        }

        public async Task<List<DetailsEntityViewModel>> GetAll()
        {
            var entities = await context.TestEntityModels
                                .Select(e => new DetailsEntityViewModel()
                                {
                                    Author = e.Author,
                                    Count = e.Count,
                                    Description = e.Description,
                                    Status = e.Status,
                                    Name = e.Name,
                                    Id = e.Id
                                })
                                .ToListAsync();

            return entities;
        }

        public async Task<DetailsEntityViewModel> GetById(string id)
        {
            var entity = await context.TestEntityModels
                            .FirstOrDefaultAsync(e => e.Id == id);

            var entityModel = new DetailsEntityViewModel()
            {
                Author = entity.Author,
                Id = entity.Id,
                Description = entity.Description,
                Status = entity.Status,
                Count = entity.Count,
                Name = entity.Name,
            };

            return entityModel;
        }
    }
}
