CREATE TABLE [dbo].[Passenger] (
    [PassengerID]        INT           IDENTITY (1, 1) NOT NULL,
    [PassengerName]      NVARCHAR (20) NOT NULL,
    [PassengerSurname]   NVARCHAR (20) NOT NULL,
    [PassengerTel]       NVARCHAR (19) NOT NULL,
    [PassengerBirthDate] DATE          NOT NULL,
    CONSTRAINT [PK_Passenger] PRIMARY KEY CLUSTERED ([PassengerID] ASC)
);

