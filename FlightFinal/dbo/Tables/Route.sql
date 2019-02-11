CREATE TABLE [dbo].[Route] (
    [RouteID]           INT           IDENTITY (1, 1) NOT NULL,
    [RouteFlightNumber] NVARCHAR (20) NOT NULL,
    [RoutePlaneID]      INT           NOT NULL,
    [RouteDepAirport]   NVARCHAR (50) NOT NULL,
    [RouteArrAirport]   NVARCHAR (50) NOT NULL,
    [RouteDepDate]      DATE          NOT NULL,
    [RouteArrTDate]     DATE          NOT NULL,
    CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED ([RouteID] ASC),
    CONSTRAINT [FK_Route_Plane] FOREIGN KEY ([RoutePlaneID]) REFERENCES [dbo].[Plane] ([PlaneID])
);

