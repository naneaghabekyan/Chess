Use ChessDataBase
--CREATE TABLE Players
--(
--    PlayerId INT IDENTITY(1,1) PRIMARY KEY,
--    Nickname NVARCHAR(50) NOT NULL UNIQUE,
--    Rank INT NOT NULL DEFAULT 1000
--);

--CREATE TABLE Matches
--(
--    MatchId INT IDENTITY(1,1) PRIMARY KEY,
--    MatchType NVARCHAR(20) NOT NULL,
--    StartTime DATETIME2 NOT NULL,
--    EndTime DATETIME2 NULL,

--    CONSTRAINT CK_Matches_MatchType
--        CHECK (MatchType IN ('Ranked', 'Casual'))
--);

--CREATE TABLE MatchPlayers
--(
--    MatchId INT NOT NULL,
--    PlayerId INT NOT NULL,
--    Result NVARCHAR(10) NOT NULL,

--    CONSTRAINT PK_MatchPlayers
--        PRIMARY KEY (MatchId, PlayerId),

--    CONSTRAINT FK_MatchPlayers_Matches
--        FOREIGN KEY (MatchId) REFERENCES Matches(MatchId),

--    CONSTRAINT FK_MatchPlayers_Players
--        FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId),

--    CONSTRAINT CK_MatchPlayers_Result
--        CHECK (Result IN ('Win', 'Lose', 'Draw'))
--);





