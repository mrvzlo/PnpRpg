using System;
using AutoMapper;

namespace Pnprpg.Domain.Services
{
    public class BaseService
    {
        protected IMapper Mapper;

        protected IConfigurationProvider MapperConfig => Mapper.ConfigurationProvider;

        public BaseService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
