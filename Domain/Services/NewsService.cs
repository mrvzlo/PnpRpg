using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class NewsService : BaseService, INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(IMapper mapper, INewsRepository newsRepository) : base(mapper)
        {
            _newsRepository = newsRepository;
        }

        public NewsViewModel GetLatest() => GetAll().First();

        public NewsEditModel GetForEdit(int? id)
        {
            if (id == null)
                return new NewsEditModel();
            var model = _newsRepository.Get(id.Value).ProjectTo<NewsEditModel>(MapperConfig).FirstOrDefault();
            return model ?? new NewsEditModel();
        }

        public void Delete(int id) => _newsRepository.Delete(id);

        public IQueryable<NewsViewModel> GetAll() => 
            _newsRepository.Select().ProjectTo<NewsViewModel>(MapperConfig).OrderByDescending(x => x.Date);

        public int Save(NewsEditModel model)
        {
            var news = new News
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                Date = model.Date
            };

            return _newsRepository.InsertOrUpdate(news);
        }
    }
}
