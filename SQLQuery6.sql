USE [game]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE AbilityClass(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[abilityName] NVARCHAR (100) NOT NULL,
	[abilityDmg] INT NOT NULL,
	[abilityStaminaCost] INT NOT NULL,
	[abilityImgPath] NVARCHAR (150) NOT NULL,
);


CREATE TABLE AbilityIndex(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[foreignKey] int FOREIGN KEY REFERENCES AbilityClass(id),
	[playerId] INT NOT NULL
);


CREATE TABLE ConsumeClass(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[value] INT NOT NULL,
	[iconPath] NVARCHAR (250) NOT NULL,
	[itemName] NVARCHAR (250) NOT NULL,
	[healEffect] INT NOT NULL,
	[description] NVARCHAR (250) NOT NULL,
);


CREATE TABLE ArmourClass(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[value] INT NOT NULL,
	[iconPath] NVARCHAR (250) NOT NULL,
	[itemName] NVARCHAR (250) NOT NULL,
	[defEffect] INT NOT NULL,
	[description] NVARCHAR (250) NOT NULL,
	[isHelmet] BIT NOT NULL
);

CREATE TABLE WeaponClass(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[value] INT NOT NULL,
	[iconPath] NVARCHAR (250) NOT NULL,
	[itemName] NVARCHAR (250) NOT NULL,
	[isLegendary] BIT NOT NULL,
	[description] NVARCHAR (250) NOT NULL,
	[attackEffect] INT NOT NULL
);


CREATE TABLE InventoryIndex(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[consumeItemId] int FOREIGN KEY REFERENCES ConsumeClass(id),
	[armourItemId] int FOREIGN KEY REFERENCES ArmourClass(id),
	[weaponItemId] int FOREIGN KEY REFERENCES WeaponClass(id),
	
);
CREATE TABLE PlayerClass(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[className] NVARCHAR (100) NOT NULL,
	[def] INT NOT NULL,
	[maxHp] INT NOT NULL,
	[maxStamina] INT NOT NULL,
	[foreignKey] int FOREIGN KEY REFERENCES AbilityIndex(id),

);
CREATE TABLE Player(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[foreignKey] int FOREIGN KEY REFERENCES PlayerClass(id),
	[playerName] NVARCHAR (250) NOT NULL,
	[playerLvl] INT NOT NULL,
	[xp] INT NOT NULL,
	[nextLvlUp] INT NOT NULL,
	[strength] INT NOT NULL,
	[agility] INT NOT NULL,
	[luck] INT NOT NULL,
	[gold] INT NOT NULL,
	[inventoryIndex] INT FOREIGN KEY REFERENCES InventoryIndex(id)
	);

CREATE TABLE Enemy(
	[id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[hp] INT NOT NULL,
	[name] NVARCHAR (250) NOT NULL,
	[imgPath] NVARCHAR (250) NOT NULL,
	[isBoss] BIT NOT NULL,
	[power] INT NOT NULL,
	[xpReward] INT NOT NULL,
	[goldReward] INT NOT NULL,
	[dungoenId] INT NOT NULL
);

CREATE TABLE Dungoen(
	[id] INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[dungoenName] NVARCHAR (250) NOT NULL,
	[dungoenDifficulty] INT NOT NULL,
	[exReward] INT NOT NULL,
	[reqLvl] INT NOT NULL,
	[imgPath] NVARCHAR (250) NOT NULL,
	[imgBgPath] NVARCHAR (250) NOT NULL,
);





SET IDENTITY_INSERT [ConsumeClass] ON
INSERT INTO [ConsumeClass] ([id], [value], [iconPath], [itemName], [healEffect], [description]) VALUES(1, 80, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/potion1.png', 'Small Healing Potion', 30, 'A small potion that heals you for 30 HP')
INSERT INTO [ConsumeClass] ([id], [value], [iconPath], [itemName], [healEffect], [description]) VALUES(2, 120, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/potion2.png', 'Healing Potion', 40, 'Healing potion that heals you for 40 HP')
INSERT INTO [ConsumeClass] ([id], [value], [iconPath], [itemName], [healEffect], [description]) VALUES(3, 50, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/food1.png', 'Small Chunk of Meat', 25, 'A small chunk of meat that heals you for 25HP')
INSERT INTO [ConsumeClass] ([id], [value], [iconPath], [itemName], [healEffect], [description]) VALUES(4, 65, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/food2.png', 'Chunk of Meat', 35, 'Chunk of meat that heals you for 35 HP')
INSERT INTO [ConsumeClass] ([id], [value], [iconPath], [itemName], [healEffect], [description]) VALUES(5, 100, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/consumeItems/food3.png', 'Large Chunk of Meat', 45, 'Large chunk of meat that heals you for 45 HP')
SET IDENTITY_INSERT [ConsumeClass] OFF


SET IDENTITY_INSERT [ArmourClass] ON
INSERT INTO [ArmourClass] ([id], [value], [iconPath], [itemName], [defEffect], [description], [isHelmet]) VALUES(1, 350, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour1helm.png', 'Leather Helm', 1, 'A Helm made from Leather, usually worn by peasents of the South.', 0)
INSERT INTO [ArmourClass] ([id], [value], [iconPath], [itemName], [defEffect], [description], [isHelmet]) VALUES(2, 450, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour1chest.png', 'Leather Chestplate', 3, 'A chest plate made from Leather, usually worn by peasents of the South.', 1)
INSERT INTO [ArmourClass] ([id], [value], [iconPath], [itemName], [defEffect], [description], [isHelmet]) VALUES(3, 3050, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour2helm.png', 'Iron Helm', 3, 'A strong helm made of iron. Belongs to the Wests knight armour set.', 0)
INSERT INTO [ArmourClass] ([id], [value], [iconPath], [itemName], [defEffect], [description], [isHelmet]) VALUES(4, 3500, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour2chest.png', 'Iron Chestplate', 5, 'A strong chest plate made of iron. Belongs to the Wests knight armour set', 1)
INSERT INTO [ArmourClass] ([id], [value], [iconPath], [itemName], [defEffect], [description], [isHelmet]) VALUES(5, 10050, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour3helm.png', 'Holy Gold helm', 6, 'A divine helm made of the holy gold from the Black Rock Mountain.', 0)
INSERT INTO [ArmourClass] ([id], [value], [iconPath], [itemName], [defEffect], [description], [isHelmet]) VALUES(6, 13350, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/armourItems/armour3chest.png', 'Holy Gold Chestplate', 7, 'A divine chest plate made of the holy gold from the Black Rock Mountain.', 1)
SET IDENTITY_INSERT [ArmourClass] OFF

SET IDENTITY_INSERT [WeaponClass] ON
INSERT INTO [WeaponClass] ([id], [value], [iconPath], [itemName], [attackEffect], [description], [isLegendary]) VALUES(1, 200, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword1.png', 'Peasent Sword', 5, 'Peasent sword, usually weilded by the lower class people.', 1)
INSERT INTO [WeaponClass] ([id], [value], [iconPath], [itemName], [attackEffect], [description], [isLegendary]) VALUES(2, 350, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword2.png', 'Solid Iron Sword', 8, 'A sword of solid iron. Weilded by the knights of the South.', 1)
INSERT INTO [WeaponClass] ([id], [value], [iconPath], [itemName], [attackEffect], [description], [isLegendary]) VALUES(3, 700, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword3.png', 'Blessed Iron Sword', 11, 'A sword mode of solid iron which has been blessed by the archbishop', 1)
INSERT INTO [WeaponClass] ([id], [value], [iconPath], [itemName], [attackEffect], [description], [isLegendary]) VALUES(4, 8000, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword4.png', 'Holy Frost Sword', 16, '"A holy sword blessed by the frost gods. A hit from this sword will result in the enemy facing the mighty frost gods waith', 0)
INSERT INTO [WeaponClass] ([id], [value], [iconPath], [itemName], [attackEffect], [description], [isLegendary]) VALUES(5, 30000, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/items/weaponItems/sword5.png', 'Blessed Dark Iron Sword', 20, 'A sword made of the rarest minerals from the deepest depts of hell. A hit from this sword will cast your eneimes in hell fire', 0)
SET IDENTITY_INSERT [WeaponClass] OFF


SET IDENTITY_INSERT [Enemy] ON
INSERT INTO [Enemy] (id, hp, name, imgPath, isBoss, power, xpReward, goldReward, dungoenId) VALUES(1, 60, 'Wild Goblin', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/download.png', 0, 13, 20, 50, 1)
INSERT INTO [Enemy] (id, hp, name, imgPath, isBoss, power, xpReward, goldReward, dungoenId) VALUES(2, 80, 'Rogue Pumpkin Farmer', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/pumpkinMan.png', 0, 3, 40, 120, 1)
INSERT INTO [Enemy] (id, hp, name, imgPath, isBoss, power, xpReward, goldReward, dungoenId) VALUES(3, 80, 'Gaara of Sand', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/sand2.gif', 0, 17, 50, 200, 2)
INSERT INTO [Enemy] (id, hp, name, imgPath, isBoss, power, xpReward, goldReward, dungoenId) VALUES(4, 120, 'Sand Howler', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/sand.gif', 1, 20, 70, 240, 2)
INSERT INTO [Enemy] (id, hp, name, imgPath, isBoss, power, xpReward, goldReward, dungoenId) VALUES(5, 100, 'Flame Bison', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/lavaEnemy1.gif', 0, 20, 100, 300, 3)
INSERT INTO [Enemy] (id, hp, name, imgPath, isBoss, power, xpReward, goldReward, dungoenId) VALUES(6, 150, 'Cinder Monster', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/Enemy/lavaBoss3.png', 1, 27, 140, 380, 3)
SET IDENTITY_INSERT [Enemy] OFF


SET IDENTITY_INSERT [Dungoen] ON
INSERT INTO [Dungoen] (id, dungoenName, dungoenDifficulty, exReward, reqLvl, imgPath, imgBgPath) VALUES(1, 'Chambers of the Unknown Forest', 1, 120, 0, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area1/areaLoading.png', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area1/areabg.png')
INSERT INTO [Dungoen] (id, dungoenName, dungoenDifficulty, exReward, reqLvl, imgPath, imgBgPath) VALUES(2, 'The Desert Caverns', 3, 250, 0, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2/areaLoading.png', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2/areaBg.png')
INSERT INTO [Dungoen] (id, dungoenName, dungoenDifficulty, exReward, reqLvl, imgPath, imgBgPath) VALUES(3, 'The Bloodfall Catacombs', 5, 600, 0, 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3/areaLoading.png', 'C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3/areaBg.png')
SET IDENTITY_INSERT [Dungoen] OFF
