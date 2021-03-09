using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Pnprpg.DomainService.IRepositories;
using Pnprpg.DomainService.IServices;
using Pnprpg.DomainService.Models;

namespace Pnprpg.Domain.Services
{
    public class DonationService : BaseService, IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IMapper mapper, IDonationRepository donationRepository) : base(mapper)
        {
            _donationRepository = donationRepository;
        }

        public IQueryable<DonationViewModel> GetAll() => 
            _donationRepository.Select().ProjectTo<DonationViewModel>(MapperConfig);

        public IQueryable<DonationEditModel> GetEditModels() => _donationRepository.Select().ProjectTo<DonationEditModel>(MapperConfig);

        public void SaveAll(List<DonationEditModel> list)
        {
            var donations = _donationRepository.Select().ToList();
            foreach (var donation in donations)
            {
                var model = list.Find(x => x.Id == donation.Id);
                donation.Current = Math.Floor(model.Current * 100) / 100;
                donation.Total = Math.Floor(model.Total * 100) / 100;
            }
            _donationRepository.BatchInsert(donations.AsQueryable());
        }
    }
}
