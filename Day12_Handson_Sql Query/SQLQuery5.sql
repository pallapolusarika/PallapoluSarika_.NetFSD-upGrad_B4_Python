--------------------------------------------------
-- USE DATABASE
--------------------------------------------------
USE EventDb;
GO

--------------------------------------------------
-- DROP TABLES (If Already Exists)
--------------------------------------------------

IF OBJECT_ID('ParticipantEventDetails', 'U') IS NOT NULL
DROP TABLE ParticipantEventDetails;

IF OBJECT_ID('SessionInfo', 'U') IS NOT NULL
DROP TABLE SessionInfo;

IF OBJECT_ID('SpeakersDetails', 'U') IS NOT NULL
DROP TABLE SpeakersDetails;

IF OBJECT_ID('EventDetails', 'U') IS NOT NULL
DROP TABLE EventDetails;

IF OBJECT_ID('UserInfo', 'U') IS NOT NULL
DROP TABLE UserInfo;

--------------------------------------------------
-- 1. UserInfo Table
--------------------------------------------------

CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL 
        CHECK (LEN(UserName) BETWEEN 1 AND 50),
    Role VARCHAR(20) NOT NULL 
        CHECK (Role IN ('Admin', 'Participant')),
    Password VARCHAR(20) NOT NULL 
        CHECK (LEN(Password) BETWEEN 6 AND 20)
);

--------------------------------------------------
-- 2. EventDetails Table
--------------------------------------------------

CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL
        CHECK (LEN(EventName) BETWEEN 1 AND 50),
    EventCategory VARCHAR(50) NOT NULL
        CHECK (LEN(EventCategory) BETWEEN 1 AND 50),
    EventDate DATETIME NOT NULL,
    Description VARCHAR(255),
    Status VARCHAR(20)
        CHECK (Status IN ('Active', 'In-Active'))
);

--------------------------------------------------
-- 3. SpeakersDetails Table
--------------------------------------------------

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL
        CHECK (LEN(SpeakerName) BETWEEN 1 AND 50)
);

--------------------------------------------------
-- 4. SessionInfo Table
--------------------------------------------------

CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL,
    SessionTitle VARCHAR(50) NOT NULL
        CHECK (LEN(SessionTitle) BETWEEN 1 AND 50),
    SpeakerId INT NOT NULL,
    Description VARCHAR(255),
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(255),

    CONSTRAINT FK_Session_Event
        FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Session_Speaker
        FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

--------------------------------------------------
-- 5. ParticipantEventDetails Table
--------------------------------------------------

CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL,
    EventId INT NOT NULL,
    SessionId INT NOT NULL,
    IsAttended BIT CHECK (IsAttended IN (0,1)),

    CONSTRAINT FK_Participant_User
        FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),

    CONSTRAINT FK_Participant_Event
        FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),

    CONSTRAINT FK_Participant_Session
        FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);

--------------------------------------------------
-- INSERT SAMPLE DATA
--------------------------------------------------

INSERT INTO UserInfo VALUES
('admin@gmail.com','AdminUser','Admin','admin123'),
('user1@gmail.com','Sarika','Participant','pass123');

INSERT INTO EventDetails VALUES
(1,'Tech Conference','Technology','2026-04-10','AI and Cloud Event','Active');

INSERT INTO SpeakersDetails VALUES
(101,'John Smith');

INSERT INTO SessionInfo VALUES
(201,1,'AI Session',101,'Introduction to AI',
'2026-04-10 10:00:00','2026-04-10 11:00:00',
'www.sessionlink.com');

INSERT INTO ParticipantEventDetails VALUES
(1,'user1@gmail.com',1,201,1);

--------------------------------------------------
-- SELECT DATA
--------------------------------------------------

SELECT * FROM UserInfo;
SELECT * FROM EventDetails;
SELECT * FROM SpeakersDetails;
SELECT * FROM SessionInfo;
SELECT * FROM ParticipantEventDetails;

--------------------------------------------------
-- JOIN QUERY
--------------------------------------------------

SELECT 
    u.UserName,
    e.EventName,
    s.SessionTitle,
    sp.SpeakerName,
    p.IsAttended
FROM ParticipantEventDetails p
JOIN UserInfo u 
    ON p.ParticipantEmailId = u.EmailId
JOIN EventDetails e 
    ON p.EventId = e.EventId
JOIN SessionInfo s 
    ON p.SessionId = s.SessionId
JOIN SpeakersDetails sp 
    ON s.SpeakerId = sp.SpeakerId;
