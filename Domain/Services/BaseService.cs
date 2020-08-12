using System;
using AutoMapper;

namespace Pnprpg.Domain.Services
{
    public class BaseService
    {
        public Lazy<IMapper> MapperInstance { protected get; set; }

        protected IMapper Mapper => MapperInstance.Value;

        protected IConfigurationProvider MapperConfig => Mapper.ConfigurationProvider;
    }
}
