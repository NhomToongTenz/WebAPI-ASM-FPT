-- Tạo cơ sở dữ liệu GameDB nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'GameDB')
CREATE DATABASE GameDB;
GO

-- Sử dụng cơ sở dữ liệu GameDB
USE GameDB;
GO

-- Tạo bảng Player
IF OBJECT_ID(N'Player', N'U') IS NULL
CREATE TABLE Player (
                        Player_id INT PRIMARY KEY IDENTITY,
                        Email NVARCHAR(255) NOT NULL,
                        Password NVARCHAR(255) NOT NULL,
                        Character_name NVARCHAR(255) NOT NULL,
                        Level INT NOT NULL,
                        Food INT NOT NULL,
                        Health INT NOT NULL,
                        Exp INT NOT NULL
);
GO

-- Tạo bảng Game_Mode
IF OBJECT_ID(N'Game_Mode', N'U') IS NULL
CREATE TABLE Game_Mode (
                           GameMode_id INT PRIMARY KEY IDENTITY,
                           GameMode_name NVARCHAR(255) NOT NULL
);
GO

-- Tạo bảng Player_GameMode
IF OBJECT_ID(N'Player_GameMode', N'U') IS NULL
CREATE TABLE Player_GameMode (
                                 Player_GameMode_id INT PRIMARY KEY IDENTITY,
                                 Player_id INT NOT NULL,
                                 GameMode_id INT NOT NULL,
                                 FOREIGN KEY (Player_id) REFERENCES Player(Player_id),
                                 FOREIGN KEY (GameMode_id) REFERENCES Game_Mode(GameMode_id)
);
GO

-- Tạo bảng Item
IF OBJECT_ID(N'Item', N'U') IS NULL
CREATE TABLE Item (
                      Item_id INT PRIMARY KEY IDENTITY,
                      Item_name NVARCHAR(255),
                      Image VARBINARY(MAX),
                      Item_type NVARCHAR(255),
                      Exp INT
);
GO

-- Tạo bảng Player_Items
IF OBJECT_ID(N'Player_Items', N'U') IS NULL
CREATE TABLE Player_Items (
                              Player_Item_id INT PRIMARY KEY IDENTITY,
                              Player_id INT NOT NULL,
                              Item_id INT NOT NULL,
                              FOREIGN KEY (Player_id) REFERENCES Player(Player_id),
                              FOREIGN KEY (Item_id) REFERENCES Item(Item_id)
);
GO

-- Tạo bảng Resources
IF OBJECT_ID(N'Resources', N'U') IS NULL
CREATE TABLE Resources (
                           Resource_id INT PRIMARY KEY IDENTITY,
                           Resource_name NVARCHAR(255) NOT NULL
);
GO

-- Tạo bảng Player_Resources
IF OBJECT_ID(N'Player_Resources', N'U') IS NULL
CREATE TABLE Player_Resources (
                                  Player_Resource_id INT PRIMARY KEY IDENTITY,
                                  Player_id INT NOT NULL,
                                  Resource_id INT NOT NULL,
                                  Quantity INT NOT NULL,
                                  FOREIGN KEY (Player_id) REFERENCES Player(Player_id),
                                  FOREIGN KEY (Resource_id) REFERENCES Resources(Resource_id)
);
GO

-- Tạo bảng Vehicles
IF OBJECT_ID(N'Vehicles', N'U') IS NULL
CREATE TABLE Vehicles (
                          Vehicle_id INT PRIMARY KEY IDENTITY,
                          Vehicle_name NVARCHAR(255) NOT NULL
);
GO

-- Tạo bảng Player_Vehicles
IF OBJECT_ID(N'Player_Vehicles', N'U') IS NULL
CREATE TABLE Player_Vehicles (
                                 Player_Vehicle_id INT PRIMARY KEY IDENTITY,
                                 Player_id INT NOT NULL,
                                 Vehicle_id INT NOT NULL,
                                 FOREIGN KEY (Player_id) REFERENCES Player(Player_id),
                                 FOREIGN KEY (Vehicle_id) REFERENCES Vehicles(Vehicle_id)
);
GO

-- Tạo bảng Quests
IF OBJECT_ID(N'Quests', N'U') IS NULL
CREATE TABLE Quests (
                        Quest_id INT PRIMARY KEY IDENTITY,
                        Quest_name NVARCHAR(255) NOT NULL,
                        Reward_exp INT,
                        Reward_item_id INT,
                        FOREIGN KEY (Reward_item_id) REFERENCES Item(Item_id)
);
GO

-- Tạo bảng Player_Quests
IF OBJECT_ID(N'Player_Quests', N'U') IS NULL
CREATE TABLE Player_Quests (
                               Player_Quest_id INT PRIMARY KEY IDENTITY,
                               Player_id INT NOT NULL,
                               Quest_id INT NOT NULL,
                               Status NVARCHAR(255) NOT NULL,
                               FOREIGN KEY (Player_id) REFERENCES Player(Player_id),
                               FOREIGN KEY (Quest_id) REFERENCES Quests(Quest_id)
);
GO


-- Chèn dữ liệu mẫu vào bảng Player
INSERT INTO Player (Email, Password, Character_name, Level, Food, Health, Exp)
VALUES
    ('player1@example.com', 'password1', 'Warrior1', 10, 50, 100, 200),
    ('player2@example.com', 'password2', 'Mage2', 20, 70, 150, 400),
    ('player3@example.com', 'password3', 'Archer3', 15, 60, 120, 300),
    ('player4@example.com', 'password4', 'Knight4', 25, 80, 200, 500),
    ('player5@example.com', 'password5', 'Assassin5', 30, 90, 250, 600);

-- Chèn dữ liệu mẫu vào bảng Game_Mode
INSERT INTO Game_Mode (GameMode_name)
VALUES
    ('Survival'),
    ('Creative'),
    ('Adventure'),
    ('Spectator');

-- Chèn dữ liệu mẫu vào bảng Player_GameMode
INSERT INTO Player_GameMode (Player_id, GameMode_id)
VALUES
    (1, 1), -- Player 1 chọn chế độ Sinh tồn
    (2, 2), -- Player 2 chọn chế độ Sáng tạo
    (3, 3), -- Player 3 chọn chế độ Phiêu lưu
    (4, 4), -- Player 4 chọn chế độ Khán giả
    (5, 1); -- Player 5 chọn chế độ Sinh tồn

-- Chèn dữ liệu mẫu vào bảng Item
INSERT INTO Item (Item_name, Image, Item_type, Exp)
VALUES
    ('Sword', NULL, 'Weapon', 50),
    ('Health Potion', NULL, 'Potion', 20),
    ('Shield', NULL, 'Armor', 40),
    ('Magic Staff', NULL, 'Weapon', 60),
    ('Bow', NULL, 'Weapon', 55);

-- Chèn dữ liệu mẫu vào bảng Player_Items
INSERT INTO Player_Items (Player_id, Item_id)
VALUES
    (1, 1), -- Player 1 sở hữu Sword
    (2, 2), -- Player 2 sở hữu Health Potion
    (3, 3), -- Player 3 sở hữu Shield
    (4, 4), -- Player 4 sở hữu Magic Staff
    (5, 5); -- Player 5 sở hữu Bow

-- Chèn dữ liệu mẫu vào bảng Resources
INSERT INTO Resources (Resource_name)
VALUES
    ('Wood'),
    ('Stone'),
    ('Iron'),
    ('Gold'),
    ('Diamond');

-- Chèn dữ liệu mẫu vào bảng Player_Resources
INSERT INTO Player_Resources (Player_id, Resource_id, Quantity)
VALUES
    (1, 1, 100), -- Player 1 thu thập 100 Wood
    (2, 2, 150), -- Player 2 thu thập 150 Stone
    (3, 3, 200), -- Player 3 thu thập 200 Iron
    (4, 4, 250), -- Player 4 thu thập 250 Gold
    (5, 5, 300); -- Player 5 thu thập 300 Diamond

-- Chèn dữ liệu mẫu vào bảng Vehicles
INSERT INTO Vehicles (Vehicle_name)
VALUES
    ('Horse'),
    ('Boat'),
    ('Minecart');

-- Chèn dữ liệu mẫu vào bảng Player_Vehicles
INSERT INTO Player_Vehicles (Player_id, Vehicle_id)
VALUES
    (1, 1), -- Player 1 sở hữu Horse
    (2, 2), -- Player 2 sở hữu Boat
    (3, 3), -- Player 3 sở hữu Minecart
    (4, 1), -- Player 4 sở hữu Horse
    (5, 2); -- Player 5 sở hữu Boat

-- Chèn dữ liệu mẫu vào bảng Quests
INSERT INTO Quests (Quest_name, Reward_exp, Reward_item_id)
VALUES
    ('Survive the Night', 100, 1), -- Nhiệm vụ "Survive the Night", phần thưởng là 100 Exp và Sword
    ('Defeat the Boss', 200, 2),   -- Nhiệm vụ "Defeat the Boss", phần thưởng là 200 Exp và Health Potion
    ('Collect Resources', 150, 3), -- Nhiệm vụ "Collect Resources", phần thưởng là 150 Exp và Shield
    ('Find the Treasure', 250, 4), -- Nhiệm vụ "Find the Treasure", phần thưởng là 250 Exp và Magic Staff
    ('Explore the Dungeon', 300, 5); -- Nhiệm vụ "Explore the Dungeon", phần thưởng là 300 Exp và Bow

-- Chèn dữ liệu mẫu vào bảng Player_Quests
INSERT INTO Player_Quests (Player_id, Quest_id, Status)
VALUES
    (1, 1, 'Completed'), -- Player 1 đã hoàn thành nhiệm vụ "Survive the Night"
    (2, 2, 'In Progress'), -- Player 2 đang tham gia nhiệm vụ "Defeat the Boss"
    (3, 3, 'Not Started'), -- Player 3 chưa bắt đầu nhiệm vụ "Collect Resources"
    (4, 4, 'Completed'), -- Player 4 đã hoàn thành nhiệm vụ "Find the Treasure"
    (5, 5, 'In Progress'); -- Player 5 đang tham gia nhiệm vụ "Explore the Dungeon"
