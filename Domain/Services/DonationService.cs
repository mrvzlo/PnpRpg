using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class DonationService : BaseService, IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public IQueryable<DonationViewModel> GetAll() => _donationRepository.Select().ProjectTo<DonationViewModel>(MapperConfig);

        public IQueryable<DonationEditModel> GetEditModels() => _donationRepository.Select().ProjectTo<DonationEditModel>(MapperConfig);

        public void SaveAll(List<DonationEditModel> list)
        {
            var donations = _donationRepository.Select().ToList();
            foreach (var donation in donations)
            {
                var model = list.Find(x => x.Id == donation.Id);
                donation.Current = model.Current;
                donation.Total = model.Total;
            }
            _donationRepository.BatchInsert(donations.AsQueryable());
        }
    }
}
