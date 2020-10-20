﻿using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.Entities;
using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class NewsService : BaseService, INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public NewsEditModel GetForEdit(int? id)
        {
            var news = id == null ? new News(){Date = DateTime.Now} : _newsRepository.Get(id.Value);
            return Mapper.Map<NewsEditModel>(news);
        }

        public void Delete(int id) => _newsRepository.Delete(id);

        public IQueryable<NewsViewModel> GetAll() => 
            _newsRepository.Select().ProjectTo<NewsViewModel>(MapperConfig).OrderByDescending(x => x.Date);

        public void Save(NewsEditModel model)
        {
            var news = new News
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                Date = model.Date
            };

            model.Id = _newsRepository.InsertOrUpdate(news);
        }
    }
}