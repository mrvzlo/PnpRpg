﻿using Boot.Enums;

namespace Boot.Models.JsonModels
{
    public class SkillInfo
    {
        public int Id, Difficulty, Level;
        public bool CanInc;
        public string Name;
        public StatType Stat;
    }
}