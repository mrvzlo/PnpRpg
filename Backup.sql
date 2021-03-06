SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abilities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Symbol] [nchar](1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Influence] [nvarchar](max) NOT NULL,
	[Color] [nvarchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlchemySymbols](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Value] [int] NOT NULL,
	[SymbolType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bonuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Icon] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchBonuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BranchId] [int] NOT NULL,
	[BonusId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Color] [nchar](6) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MagicSchools](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Color] [nchar](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[BranchId] [int] NOT NULL,
	[Max] [int] NOT NULL,
	[Level] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Potions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PotionType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RaceAbilities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RaceId] [int] NOT NULL,
	[AbilityId] [int] NOT NULL,
	[Value] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RaceBonuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RaceId] [int] NOT NULL,
	[BonusId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Races](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Karma] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Reagent] [int] NOT NULL,
	[Process] [int] NOT NULL,
	[PotionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AbilityId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[Difficulty] [int] NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spells](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Level] [int] NOT NULL,
	[MagicSchoolId] [int] NOT NULL,
	[Damage] [int] NOT NULL,
	[Cost] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Effect] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TraitEffects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [int] NOT NULL,
	[TargetId] [int] NOT NULL,
	[TargetType] [int] NOT NULL,
	[TraitId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weapons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Level] [int] NOT NULL,
	[SkillId] [int] NOT NULL,
	[Weight] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeaponsBonuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WeaponId] [int] NOT NULL,
	[BonusId] [int] NOT NULL,
 CONSTRAINT [PK_WeaponsBonuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Abilities] ON 

INSERT [dbo].[Abilities] ([Id], [Name], [Symbol], [Description], [Influence], [Color]) VALUES (1, N'Сила', N'S', N'Физическая сила', N'Боевые навыки, тяжёлый физический труд', N'922')
INSERT [dbo].[Abilities] ([Id], [Name], [Symbol], [Description], [Influence], [Color]) VALUES (2, N'Выносливость', N'E', N'Стойкость и психическое здоровье', N'Сопротивляемость урону, запас здоровья', N'a60')
INSERT [dbo].[Abilities] ([Id], [Name], [Symbol], [Description], [Influence], [Color]) VALUES (3, N'Ловкость', N'A', N'Проворство, гибкость, координация', N'Скрытность, взлом, воровство, передвижение', N'282')
INSERT [dbo].[Abilities] ([Id], [Name], [Symbol], [Description], [Influence], [Color]) VALUES (4, N'Интеллект', N'I', N'Восприятие, интуиция, память', N'Создание заклинаний, общение', N'229')
SET IDENTITY_INSERT [dbo].[Abilities] OFF
GO
SET IDENTITY_INSERT [dbo].[AlchemySymbols] ON 

INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (1, N'☉', N'Свет', 0, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (2, N'☾', N'Тьма', 1, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (3, N'☿', N'Огонь', 2, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (4, N'♀', N'Огонь', 2, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (5, N'♂', N'Земля', 3, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (6, N'♃', N'Воздух', 4, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (7, N'♄', N'Воздух', 4, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (8, N'♅', N'Земля', 3, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (9, N'♆', N'Вода', 5, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (10, N'●)+', N'Вода', 5, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (11, N'☊', N'Свет', 0, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (12, N'☋', N'Тьма', 1, 0)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (13, N'♈', N'Нагревание', 0, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (14, N'♉', N'Осушение', 1, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (15, N'♊', N'Остывание', 2, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (16, N'♋', N'Растворение', 3, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (17, N'♌', N'Нагревание', 0, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (18, N'♍', N'Осушение', 1, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (19, N'♎', N'Остывание', 1, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (20, N'♏', N'Растворение', 3, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (21, N'♐', N'Нагревание', 0, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (22, N'♑', N'Осушение', 1, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (23, N'♒', N'Остывание', 1, 1)
INSERT [dbo].[AlchemySymbols] ([Id], [Symbol], [Name], [Value], [SymbolType]) VALUES (24, N'♓', N'Растворение', 3, 1)
SET IDENTITY_INSERT [dbo].[AlchemySymbols] OFF
GO
SET IDENTITY_INSERT [dbo].[Bonuses] ON 

INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (1, N'Оглушение', N'🤕', NULL, 0)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (2, N'Разоружение', N'🖐', NULL, 0)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (3, N'Пробитие', N'🛡', NULL, 0)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (5, N'Копание', N'⛏️', NULL, 0)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (8, N'Ночное зрение', NULL, N'<p>Существо не получает штрафы к проверкам навыков в темноте</p>', 2)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (9, N'Медитация', NULL, N'<p>Вместо привычного сна существо может пребывать в состоянии медитации, восстанавливая свои жизенные силы за вдвое короткий срок.<br></p>', 2)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (10, N'Защита от холода', NULL, N'<p>Сопротивление урону от холода 1 уровня<br></p>', 2)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (11, N'Полёт', NULL, N'<p>Позволяет преодолевать короткие расстояния по воздуху<br></p>', 2)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (12, N'Хвост', NULL, N'<p>Может использоваться как оружие ближнего боя даже если персонаж обездвижен, но не позволяет носить тяжёлую броню<br></p>', 2)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (13, N'Грубость', NULL, N'<p>Вы можете использовать силу как основной атрибут при проверке красноречия<br></p>', 2)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (15, N'Высокий рост', NULL, N'<p>Рост персонажа достигает от 2 до 2.5 метров, что осложняет передвижение в малых помещениях<br></p>', 2)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (16, N'Концентрация энергии', NULL, N'<p>Маг способен концентрировать свою силу в неком предмете: посохе, палочке, амулете, кольце или оружии, чтобы увеличить шанс сотворения и точность заклинания.<br></p>', 1)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (17, N'Поток оскорблений', NULL, N'<p>Персонаж способен нанести гуманоидному противнику психологический урон, который понизит шанс успеха любого следующего действия поражённого. Уровень психологического урона равен 1 за каждые 4 уровня персонажа (минимум 1).<br></p>', 1)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (18, N'Удар исподтишка ', NULL, N'<p>Если противник не знает о присутствии атакующего, любая удачная атака нанесёт дополнительно 1 единицу урона за каждые 3 уровня атакующего (минимум 1).<br></p>', 1)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (19, N'Искоренитель', NULL, N'<p>Урон по неразумным существам увеличен на 1 единицу за каждые 4 уроня нападающего (минимум 1)<br></p>', 1)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (20, N'Сильный метаболизм', NULL, N'<p>Длительность зелий и ядов, в том числе алкоголя снижена вдвое <br></p>', 2)
INSERT [dbo].[Bonuses] ([Id], [Name], [Icon], [Description], [Type]) VALUES (21, N'Храбрость', NULL, N'<p>Защита от испуга 5%<br></p>', 2)
SET IDENTITY_INSERT [dbo].[Bonuses] OFF
GO
SET IDENTITY_INSERT [dbo].[BranchBonuses] ON 

INSERT [dbo].[BranchBonuses] ([Id], [BranchId], [BonusId]) VALUES (5, 4, 19)
INSERT [dbo].[BranchBonuses] ([Id], [BranchId], [BonusId]) VALUES (6, 6, 16)
INSERT [dbo].[BranchBonuses] ([Id], [BranchId], [BonusId]) VALUES (7, 7, 17)
INSERT [dbo].[BranchBonuses] ([Id], [BranchId], [BonusId]) VALUES (9, 3, 18)
SET IDENTITY_INSERT [dbo].[BranchBonuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([Id], [Name], [Color], [Description]) VALUES (2, N'Вор', N'aee   ', NULL)
INSERT [dbo].[Branches] ([Id], [Name], [Color], [Description]) VALUES (3, N'Ассасин', N'aea   ', NULL)
INSERT [dbo].[Branches] ([Id], [Name], [Color], [Description]) VALUES (4, N'Охотник', N'eaa   ', NULL)
INSERT [dbo].[Branches] ([Id], [Name], [Color], [Description]) VALUES (5, N'Рыцарь', N'eea   ', NULL)
INSERT [dbo].[Branches] ([Id], [Name], [Color], [Description]) VALUES (6, N'Маг', N'aae   ', N'<p>Магия пронизывает все аспекты жизни любого существа. От рождения и до смерти, а иногда и после. Те немногие, кто могут обузать эту хтоническую мощь и использовать её по своему повелению, называются магами. Их пути могут заключатся, как в долгих практиках, непрерывных учениях, так и в инородном вмешательстве или врождённом даре. Не обязательно быть магом, чтобы уметь читать свитки или показывать фокусы. Но лишь глубокое понимание магии дарует способности заключать её силу в артефактах, взывать к древним сущностям, а также управлять силами природы.<br></p>')
INSERT [dbo].[Branches] ([Id], [Name], [Color], [Description]) VALUES (7, N'Бард', N'eae   ', N'<p>Слово - есть нечто большее, чем звук. Слово - это и оружие, наносящее невидимые раны, и щит, восполняющий силы. Барды, трубадуры, поэты и художники - все они используют неограниченную силу искусства. Кто-то для потехи, кто-то для наживы, а кто-то для просвящения простого люда. Наиболее талантливые обладают широким спектром умений, которые с обывательской точки зрения с творчеством не связаны вовсе. Барды доверяются чувствам, их удары в бою походят на танец, чтение заклинаний - на песнь, а сотворение зелий - на кулинарный процесс.<br></p>')
SET IDENTITY_INSERT [dbo].[Branches] OFF
GO
SET IDENTITY_INSERT [dbo].[MagicSchools] ON 

INSERT [dbo].[MagicSchools] ([Id], [GroupId], [Name], [Description], [Color]) VALUES (1, 1, N'Школа пробуждения', N'Изучает высвобождение первородной энергии в произвольной форме', N'fdd   ')
INSERT [dbo].[MagicSchools] ([Id], [GroupId], [Name], [Description], [Color]) VALUES (2, 1, N'Школа изменения', N'Изучает превращение и перемещение предметов', N'ffd   ')
INSERT [dbo].[MagicSchools] ([Id], [GroupId], [Name], [Description], [Color]) VALUES (3, 2, N'Школа некромантии', N'Изучает воскрешение мёртвых', N'ddd   ')
INSERT [dbo].[MagicSchools] ([Id], [GroupId], [Name], [Description], [Color]) VALUES (4, 2, N'Школа призыва', N'Изучает общение с материей', N'dff   ')
INSERT [dbo].[MagicSchools] ([Id], [GroupId], [Name], [Description], [Color]) VALUES (5, 3, N'Школа зачарования', N'Изучает концентрацию магической энергии в материи', N'fdf   ')
INSERT [dbo].[MagicSchools] ([Id], [GroupId], [Name], [Description], [Color]) VALUES (6, 3, N'Школа иллюзий', N'Изучает влияние на восприятие существ', N'dfd   ')
INSERT [dbo].[MagicSchools] ([Id], [GroupId], [Name], [Description], [Color]) VALUES (7, 5, N'Школа познания', N'Изучает способы общения с миром и принципы магии', N'ddf   ')
INSERT [dbo].[MagicSchools] ([Id], [GroupId], [Name], [Description], [Color]) VALUES (8, 5, N'Школа ограждения', N'Изучает защитные заклинания и проклятья', N'fff   ')
SET IDENTITY_INSERT [dbo].[MagicSchools] OFF
GO
SET IDENTITY_INSERT [dbo].[Perks] ON 

INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (1, N'Образованный', N'+1 заклинание', 6, 3, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (3, N'Крепкая кожа', N'+1 здоровье за уровень', 5, 2, 1)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (4, N'Начинающий алхимик', N'Все зелья и яды мощнее на 1 уровень', 2, 4, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (7, N'Зоркий глаз', N'Может использовать лёгкие предметы в качестве оружия', 3, 2, 1)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (8, N'Тактичность', N'Персонаж хорошо помнит своих собеседников', 7, 1, 1)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (9, N'Уроки предков', N'+1 маны за уровень', 6, 2, 1)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (10, N'Боевые когти / хвост', N'Урон без оружия выше на 1 уровень', 3, 2, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (11, N'Чистая удача', N'Переброс 1 кубика за бой', 4, 1, 1)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (12, N'Бесконечная склянка', N'Любой яд не расходуется при нанесении на оружие', 3, 1, 5)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (14, N'Рубака', N'Может держать оружие в каждой руке', 4, 1, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (15, N'Танец смерти', N'Оружие в двух руках наносят суммарный урон', 4, 1, 4)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (16, N'Стойкость', N'Персонаж не теряет равновесие при проверке выносливости', 5, 1, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (17, N'Друг животных', N'Животные не нападают', 7, 2, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (18, N'Фокусник', N'Персонаж может украсть оружие или часть брони у противника', 2, 1, 5)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (19, N'Магический кристалл', N'Урон заклинаний выше на 1 уровень', 6, 2, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (20, N'Третий глаз', N'+1 к мане за интеллект', 6, 1, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (21, N'Зачарователь', N'Может уничтожить одно оружие для зачарования другого', 4, 1, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (22, N'Специалист', N'Уменьшает откат способностей на 1 ход', 6, 2, 5)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (23, N'Громкая песнь', N'Противник делает проверку на выносливость против оглушения', 7, 1, 5)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (24, N'Тихая песнь', N'Восстанавливает 2 очка маны всем союзникам', 7, 2, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (25, N'По рукам', N'Урон выбранного противника в ближнем бою ниже на 1 уровень', 5, 2, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (26, N'Скрытый зверь', N'+2 силы при потере половины здоровья ', 5, 2, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (27, N'Оберег', N'Первый удар в бою не наносит урона', 5, 1, 5)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (28, N'Быстрая реакция', N'Персонаж может уклоняться от атак дальнего боя и заклинаний', 2, 1, 4)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (29, N'Вёрткость', N'Персонаж может атаковать лёжа, сидя или в прыжке', 4, 1, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (30, N'Заточка', N'Оружие становится мощнее на 1 уровень на 1 бой', 4, 3, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (31, N'Кровь за кровь', N'Убийство восстанавливает часть здоровья', 4, 2, 5)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (32, N'Размах', N'Урон двуручного оружия выше на 1 уровень', 5, 2, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (33, N'Подавление магии', N'При неудачной проверке интеллекта выбранный противник получает -10% к сотворению заклинаний', 7, 2, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (34, N'Чистая совесть', N'Вероятность успеха незаконного действия повышается на 10%, если персонаж не был никем замечен', 2, 1, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (35, N'Быстрый выстрел', N'Персонаж может за ход нанести дополнительный выстрел из лука или арбалета, или бросок метательного оружия. Каждое попадание расчитывается отдельно', 3, 2, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (36, N'Боевая песнь', N'Все защитные действия союзников в течение хода успешнее на 5%', 7, 2, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (37, N'Холодная сталь', N'Немагическое оружие наносит на 2 единицы урона больше', 3, 1, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (38, N'Песочный человек', N'Убийства не вызывают шум', 3, 1, 3)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (39, N'Соль на раны', N'Шанс критического попаданий повышается на 5%', 3, 1, 4)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (40, N'Быстрая рука', N'Персонаж мгновенно достаёт оружие из ножен или поднимает с пола', 2, 1, 2)
INSERT [dbo].[Perks] ([Id], [Name], [Description], [BranchId], [Max], [Level]) VALUES (41, N'Большие карманы', N'Количество носимых зелий увеличивается в 2 раза', 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Perks] OFF
GO
SET IDENTITY_INSERT [dbo].[Potions] ON 

INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (1, N'Зелье регенерации', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (2, N'Зелье лечения болезней', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (3, N'Зелье меткости', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (4, N'Зелье невидимости', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (5, N'Зелье регенерации маны', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (6, N'Зелье лечения маны', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (7, N'Зелье уклонения', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (8, N'Зелье защиты', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (9, N'Зелье концентрации', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (10, N'Зелье бережливости', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (11, N'Зелье реакции', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (12, N'Зелье скорости', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (13, N'Зелье ярости', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (14, N'Яд слепоты', 1)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (15, N'Спирт', 1)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (16, N'Зелье невесомости', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (17, N'Зелье тяжести', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (18, N'Успокоительное', 0)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (19, N'Кислота', 1)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (20, N'Яд слабости', 1)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (21, N'Яд глупости', 1)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (22, N'Яд высасывания жизни', 1)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (23, N'Дымовая бомба', 1)
INSERT [dbo].[Potions] ([Id], [Name], [PotionType]) VALUES (24, N'Чистый яд', 1)
SET IDENTITY_INSERT [dbo].[Potions] OFF
GO
SET IDENTITY_INSERT [dbo].[RaceAbilities] ON 

INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (7, 6, 1, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (8, 6, 2, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (9, 6, 4, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (10, 5, 2, 2)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (11, 5, 3, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (12, 7, 3, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (13, 7, 4, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (14, 10, 1, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (15, 10, 2, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (16, 10, 3, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (17, 4, 1, 2)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (18, 4, 4, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (19, 8, 1, 2)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (20, 8, 3, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (21, 12, 1, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (22, 12, 2, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (23, 12, 3, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (24, 11, 2, -2)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (25, 11, 4, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (26, 3, 1, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (27, 3, 2, -1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (28, 3, 3, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (29, 9, 1, -2)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (30, 9, 4, 1)
INSERT [dbo].[RaceAbilities] ([Id], [RaceId], [AbilityId], [Value]) VALUES (31, 1, 2, 1)
SET IDENTITY_INSERT [dbo].[RaceAbilities] OFF
GO
SET IDENTITY_INSERT [dbo].[RaceBonuses] ON 

INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (25, 2, 9)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (57, 6, 20)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (58, 6, 10)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (59, 5, 20)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (60, 5, 21)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (61, 7, 10)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (62, 7, 12)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (63, 10, 10)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (64, 10, 11)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (65, 10, 15)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (66, 4, 13)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (67, 4, 20)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (68, 4, 21)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (69, 8, 8)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (70, 8, 12)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (71, 12, 15)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (72, 12, 20)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (73, 11, 9)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (74, 3, 8)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (75, 3, 9)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (76, 9, 8)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (77, 9, 9)
INSERT [dbo].[RaceBonuses] ([Id], [RaceId], [BonusId]) VALUES (78, 1, 21)
SET IDENTITY_INSERT [dbo].[RaceBonuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Races] ON 

INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (1, N'Человек', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (2, N'Светлый эльф', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (3, N'Тёмный эльф', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (4, N'Орк', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (5, N'Гном', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (6, N'Ворген', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (7, N'Змеелюд', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (8, N'Полудемон', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (9, N'Тролль', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (10, N'Летун', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (11, N'Полуэльф', NULL, 0)
INSERT [dbo].[Races] ([Id], [Name], [Description], [Karma]) VALUES (12, N'Полутитан', N'<p>Бывшие небожители, спустившиеся на землю. Полутитаны - высокие и крепкие существа с металлическим цветом кожи. <br></p>', 0)
SET IDENTITY_INSERT [dbo].[Races] OFF
GO
SET IDENTITY_INSERT [dbo].[Reactions] ON 

INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (1, 0, 0, 1)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (2, 0, 1, 3)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (3, 0, 2, 6)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (4, 0, 3, 2)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (5, 5, 0, 5)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (6, 5, 1, 19)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (7, 5, 2, 18)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (8, 5, 3, 4)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (9, 3, 0, 8)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (10, 3, 1, 17)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (11, 3, 2, 9)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (12, 3, 3, 10)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (13, 4, 0, 11)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (14, 4, 1, 7)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (15, 4, 2, 16)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (16, 4, 3, 12)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (17, 2, 0, 22)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (18, 2, 1, 13)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (19, 2, 2, 14)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (20, 2, 3, 15)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (21, 1, 0, 21)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (22, 1, 1, 23)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (23, 1, 2, 20)
INSERT [dbo].[Reactions] ([Id], [Reagent], [Process], [PotionId]) VALUES (24, 1, 3, 24)
SET IDENTITY_INSERT [dbo].[Reactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Skills] ON 

INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (1, N'Колющее оружие', 3, 3, 1, 1)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (2, N'Режущее оружие', 3, 4, 2, 1)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (3, N'Дробящее оружие', 1, 4, 2, 1)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (4, N'Метательное оружие', 3, 3, 2, 1)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (5, N'Безоружный бой', 1, 5, 1, 1)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (6, N'Стрельба', 3, 3, 2, 1)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (7, N'Блокирование', 2, 5, 3, 1)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (9, N'Школа пробуждения', 4, 6, 2, 2)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (10, N'Школа изменения', 4, 6, 2, 2)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (11, N'Школа некромантии', 4, 6, 3, 2)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (12, N'Школа призыва', 4, 7, 1, 2)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (13, N'Школа зачарования', 4, 7, 2, 2)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (14, N'Школа иллюзий', 4, 7, 1, 2)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (15, N'Школа познания', 4, 6, 1, 2)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (16, N'Школа ограждения', 4, 5, 2, 2)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (17, N'Выживание', 2, 4, 3, 0)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (18, N'Алхимия', 4, 2, 1, 0)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (19, N'Взлом', 3, 2, 2, 0)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (27, N'Скрытность', 3, 2, 2, 0)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (28, N'Карманные кражи', 3, 2, 3, 0)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (29, N'Уклонение', 3, 3, 3, 0)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (30, N'Красноречие', 4, 7, 3, 0)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (31, N'Ловушки', 3, 4, 1, 0)
INSERT [dbo].[Skills] ([Id], [Name], [AbilityId], [BranchId], [Difficulty], [Type]) VALUES (33, N'Атлетика', 2, 5, 2, 0)
SET IDENTITY_INSERT [dbo].[Skills] OFF
GO
SET IDENTITY_INSERT [dbo].[Spells] ON 

INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (210, 1, 1, 1, N'3', N'Заряд молнии', N'Отскакивает по 3 целям')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (211, 1, 1, 1, N'3', N'Ледяной вихрь', N'Замедление')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (212, 1, 1, 1, N'3', N'Магическая руна', N'Ставится на землю')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (213, 1, 1, 0, N'3', N'Стена воды', N'Ослабление')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (214, 1, 1, 1, N'4', N'Землетрясение', N'Сбивает с ног')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (215, 3, 1, 2, N'5', N'Ледяной шип', N'Заморозка')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (216, 3, 1, 2, N'5', N'Воздушный кулак', N'Отталкивание')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (217, 3, 1, 2, N'5', N'Разлом', N'Сбивает с ног')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (218, 3, 1, 2, N'6', N'Грозовая стена', N'Периодический урон')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (219, 3, 1, 3, N'7', N'Шар огня', N'Горение')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (220, 5, 1, 4, N'8', N'Буран', N'Замедление')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (221, 5, 1, 4, N'9', N'Метеор', N'Горение, по области')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (222, 1, 2, 0, N'2 + поддержание', N'Телекинез', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (223, 3, 2, 0, N'4 + объём предмета', N'Трансмутация', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (224, 5, 2, 0, N'3 + вес + расстояние', N'Телепортация', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (225, 1, 3, 0, N'4', N'Воскрешение зомби', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (226, 3, 3, 0, N'6', N'Воскрешение трелла', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (227, 5, 3, 0, N'8', N'Воскрешение духа', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (228, 1, 4, 0, N'3', N'Корни', N'Опутывание')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (229, 1, 4, 2, N'4', N'Рой насекомых', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (230, 3, 4, 0, N'2 * уровень', N'Астральное оружие', N'Маг получает неломаемое оружие')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (231, 3, 4, 0, N'3 * уровень', N'Астральная броня', N'Маг получает неломаемую броню')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (232, 5, 4, 0, N'8', N'Призыв голема', N'Каменное существо с высокой защитой')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (233, 5, 4, 0, N'10', N'Призыв атронаха', N'Стихийное существо с высоким уроном')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (234, 1, 5, 0, N'2.5 * уровень – 2', N'Усиление оружия', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (235, 1, 5, 0, N'3 * уровень', N'Усиление защиты', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (236, 3, 5, 0, N'4 * уровень', N'Усиление зверя', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (237, 5, 5, 0, N'6', N'Создание свитка', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (238, 5, 5, 0, N'8', N'Создание посоха', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (239, 1, 6, 0, N'2 на себя / 3 на цель', N'Провокация', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (240, 1, 6, 0, N'3', N'Испуг', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (241, 3, 6, 0, N'5 + поддержание', N'Сокрытие', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (242, 3, 6, 0, N'4 + поддержание', N'Успокоение', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (243, 5, 6, 0, N'6', N'Паралич', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (244, 5, 6, 0, N'8', N'Гипноз', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (245, 1, 7, 0, N'1', N'Дары природы', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (246, 1, 7, 0, N'1', N'Обезвреживание ловушки', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (247, 3, 7, 0, N'2', N'Поиск жизни', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (248, 3, 7, 0, N'3', N'Поиск смерти', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (249, 3, 7, 0, N'2', N'Спиритизм', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (250, 5, 7, 0, N'4', N'Снятие порчи', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (251, 5, 7, 0, N'5', N'Снятие зачарований', N'')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (252, 1, 8, 0, N'2 * уровень', N'Восстановление', N'Лечение цели')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (253, 1, 8, 0, N'2', N'Ускорение', N'+2 к скорости всем')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (254, 1, 8, 0, N'2', N'Бонус защиты', N'+1 защиты всем')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (255, 3, 8, 1, N'4', N'Огненный плащ', N'атакующим')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (256, 3, 8, 0, N'3', N'Ледяной щит', N'Замедление атакующих')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (257, 3, 8, 0, N'3', N'Купол света', N'Защита от магии')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (258, 5, 8, 0, N'4', N'Слепота', N'Цель не видит')
INSERT [dbo].[Spells] ([Id], [Level], [MagicSchoolId], [Damage], [Cost], [Name], [Effect]) VALUES (259, 5, 8, 0, N'4', N'Глухота', N'Цель не слышит')
SET IDENTITY_INSERT [dbo].[Spells] OFF
GO
SET IDENTITY_INSERT [dbo].[TraitEffects] ON 

INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (21, 1, 0, 0, 1, N'{0} к скрытности себе и рядом стоящим', 1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (25, 3, 0, 0, 3, N'{0} к проверкам слуха и зрения', 1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (26, -3, 0, 0, 3, N'{0} к проверкам зрения', -1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (29, 1, 0, 0, 2, N'{0} к навыкам малого оружия', 1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (30, -5, 0, 0, 2, N'{0} к навыкам крупного оружия', -1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (31, 2, 0, 0, 4, N'{0} ед. урона без оружия', 1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (32, -1, 3, 1, 4, N'{0} к ловкости', -1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (33, 2, 0, 0, 5, N'{0} ед. при внезапном уроне', 1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (34, -1, 2, 1, 5, N'{0} к выносливости', -1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (35, 1, 0, 0, 7, N'{0} к проверкам при создании предметов', 1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (36, -1, 0, 0, 7, N'{0} к проверкам в бою', -1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (37, 2, 0, 0, 6, N'Длительность эффектов ниже в {0} раза', 0)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (38, -1, 0, 0, 1, N'Не может разговаривать', -1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (39, -1, 4, 1, 8, N'{0} к интеллекту', -1)
INSERT [dbo].[TraitEffects] ([Id], [Value], [TargetId], [TargetType], [TraitId], [Description], [Type]) VALUES (40, 3, 0, 0, 8, N'{0} к красноречию с противоположным полом', 1)
SET IDENTITY_INSERT [dbo].[TraitEffects] OFF
GO
SET IDENTITY_INSERT [dbo].[Traits] ON 

INSERT [dbo].[Traits] ([Id], [Name]) VALUES (1, N'Немой')
INSERT [dbo].[Traits] ([Id], [Name]) VALUES (2, N'Однорукий')
INSERT [dbo].[Traits] ([Id], [Name]) VALUES (3, N'Одноглазый')
INSERT [dbo].[Traits] ([Id], [Name]) VALUES (4, N'Толстяк')
INSERT [dbo].[Traits] ([Id], [Name]) VALUES (5, N'Камикадзе')
INSERT [dbo].[Traits] ([Id], [Name]) VALUES (6, N'Сильный иммунитет')
INSERT [dbo].[Traits] ([Id], [Name]) VALUES (7, N'Пацифист')
INSERT [dbo].[Traits] ([Id], [Name]) VALUES (8, N'Красавчик')
SET IDENTITY_INSERT [dbo].[Traits] OFF
GO
SET IDENTITY_INSERT [dbo].[Weapons] ON 

INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (1, 1, 3, 3, N'Топор')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (2, 1, 6, 2, N'Простой лук')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (3, 1, 3, 3, N'Дубина')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (4, 1, 1, 1, N'Кинжал')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (5, 1, 3, 4, N'Кирка')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (6, 2, 1, 3, N'Шпага')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (7, 2, 2, 4, N'Меч')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (8, 2, 1, 2, N'Стилет')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (9, 2, 3, 3, N'Посох')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (10, 2, 1, 5, N'Копьё')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (11, 2, 8, 3, N'Длинный лук')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (12, 3, 2, 4, N'Сабля')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (13, 3, 1, 5, N'Мечелом')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (14, 3, 8, 4, N'Арбалет')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (15, 3, 2, 5, N'Катана')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (16, 3, 3, 6, N'Булава')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (17, 4, 2, 6, N'Клеймор')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (18, 4, 3, 9, N'Молот')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (19, 4, 4, 3, N'Томагавк')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (20, 4, 3, 8, N'Секира')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (21, 4, 3, 8, N'Алебарда')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (22, 1, 1, 2, N'Сая')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (23, 2, 6, 3, N'Длинный лук')
INSERT [dbo].[Weapons] ([Id], [Level], [SkillId], [Weight], [Name]) VALUES (24, 3, 6, 4, N'Арбалет')
SET IDENTITY_INSERT [dbo].[Weapons] OFF
GO
SET IDENTITY_INSERT [dbo].[WeaponsBonuses] ON 

INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (4, 14, 3)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (10, 13, 2)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (11, 16, 3)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (12, 5, 5)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (14, 18, 1)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (15, 20, 3)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (16, 21, 3)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (17, 21, 1)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (18, 19, 3)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (19, 1, 1)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (48, 3, 1)
INSERT [dbo].[WeaponsBonuses] ([Id], [WeaponId], [BonusId]) VALUES (49, 24, 3)
SET IDENTITY_INSERT [dbo].[WeaponsBonuses] OFF
GO
ALTER TABLE [dbo].[Perks] ADD  DEFAULT ((1)) FOR [Max]
GO
ALTER TABLE [dbo].[Perks] ADD  DEFAULT ((1)) FOR [Level]
GO
ALTER TABLE [dbo].[Potions] ADD  DEFAULT ((0)) FOR [PotionType]
GO
ALTER TABLE [dbo].[Races] ADD  DEFAULT ((0)) FOR [Karma]
GO
ALTER TABLE [dbo].[Skills] ADD  DEFAULT ((1)) FOR [Difficulty]
GO
ALTER TABLE [dbo].[Skills] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Spells] ADD  DEFAULT ((0)) FOR [Damage]
GO
ALTER TABLE [dbo].[TraitEffects] ADD  DEFAULT ((1)) FOR [Value]
GO
ALTER TABLE [dbo].[TraitEffects] ADD  DEFAULT ((0)) FOR [TargetType]
GO
ALTER TABLE [dbo].[TraitEffects] ADD  CONSTRAINT [DF_TraitEffects_Type]  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [FK_SkillInfoes_Abilities] FOREIGN KEY([AbilityId])
REFERENCES [dbo].[Abilities] ([Id])
GO
ALTER TABLE [dbo].[Skills] CHECK CONSTRAINT [FK_SkillInfoes_Abilities]
GO
