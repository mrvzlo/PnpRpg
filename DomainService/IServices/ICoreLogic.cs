﻿using Pnprpg.DomainService.Enums;
using Pnprpg.DomainService.Models;

namespace Pnprpg.DomainService.IServices
{
    public interface ICoreLogic
    {
        HeroModel CreateHero(ChaosLevel chaos);
        HeroModel DecodeHero(string data);
        HeroModel LoadHero(string username);
        bool SaveHero(HeroModel hero);
        string EncodeHero(HeroModel hero);
    }
}
