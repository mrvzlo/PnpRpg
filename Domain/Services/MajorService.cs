using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class MajorService : BaseService, IMajorService
    {
        private readonly IMajorRepository _majorRepository;

        public MajorService(IMapper mapper, IMajorRepository majorRepository) : base(mapper)
        {
            _majorRepository = majorRepository;
        }

        public MajorShortModel GetShortModel(int id)
        {
            return _majorRepository.Get(id).ProjectTo<MajorShortModel>(MapperConfig).FirstOrDefault();
        }

        public IQueryable<MajorFullModel> GetAllActive()
        {
            return _majorRepository.Select().Where(x => x.Enabled).ProjectTo<MajorFullModel>(MapperConfig);
        }
    }
}
