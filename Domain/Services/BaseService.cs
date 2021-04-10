using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class BaseService
    {
        protected readonly IMapper Mapper;

        protected IConfigurationProvider MapperConfig => Mapper.ConfigurationProvider;

        protected BaseService(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected int MappingSave<T>(IBaseRepository<T> repository, IBaseEditModel model)
            where T : BaseEntity
        {
            var entity = repository.Get(model.Id).FirstOrDefault() ?? GetDefault<T>();

            var modelType = model.GetType();
            var entityType = typeof(T);

            foreach (var modelProperty in modelType.GetProperties())
            {
                var targetProperty = entityType.GetProperty(modelProperty.Name);
                if (targetProperty == null)
                    continue;
                var value = modelProperty.GetValue(model, null);
                targetProperty.SetValue(entity, value, null);
            }

            return repository.InsertOrUpdate(entity);
        }

        private T GetDefault<T>() => (T)Activator.CreateInstance(typeof(T));
    }
}
