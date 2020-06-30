﻿using System.ComponentModel;

namespace Boot.Enums
{
    public enum UserRole
    {
        [Description("Игрок")]
        Player = 0,
        [Description("Редактор")]
        Editor = 1,
        [Description("Мастер")]
        Master = 2,
        [Description("Админ")]
        Admin = 3
    }
}