CREATE TABLE [dbo].[Airport] (
    [AirportID]      INT           IDENTITY (1, 1) NOT NULL,
    [AirportName]    NVARCHAR (20) NOT NULL,
    [AirportCountry] NVARCHAR (20) NOT NULL,
    [AirportCity]    NVARCHAR (20) NOT NULL,
    [AirportAbbre]   NCHAR (3)     NOT NULL,
    CONSTRAINT [PK_Airport] PRIMARY KEY CLUSTERED ([AirportID] ASC)
);

