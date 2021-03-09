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

        public MajorShortModel GetShortModel(int id) =>
            GetActiveById(id).ProjectTo<MajorShortModel>(MapperConfig).FirstOrDefault();

        public MajorFullModel GetFullModel(int id) =>
            GetActiveById(id).ProjectTo<MajorFullModel>(MapperConfig).FirstOrDefault();

        public MajorSettings GetSettings(int id) =>
            GetActiveById(id).ProjectTo<MajorSettings>(MapperConfig).FirstOrDefault();

        public IQueryable<MajorFullModel> GetAllActive() => 
            _majorRepository.Select().Where(x => x.Enabled).ProjectTo<MajorFullModel>(MapperConfig);

        private IQueryable<Major> GetActiveById(int id) => _majorRepository.Get(id).Where(x => x.Enabled);

        public string GetVersion(int id) => GetActiveById(id).Select(x => x.Version).FirstOrDefault();
    }
}
