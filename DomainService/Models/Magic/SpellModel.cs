﻿namespace Pnprpg.DomainService.Models
{
    public class SpellModel
    {
        public int MagicSchoolId { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Effect { get; set; }
        public string Color { get; set; }

        public MagicSchoolModel MagicSchool { get; set; }
    }
}