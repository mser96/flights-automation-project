CREATE TABLE [dbo].[Plane] (
    [PlaneID]       INT           IDENTITY (1, 1) NOT NULL,
    [PlaneName]     NVARCHAR (15) NOT NULL,
    [PlaneType]     NVARCHAR (10) NOT NULL,
    [PlaneCapacity] INT           NOT NULL,
    CONSTRAINT [PK_Plane] PRIMARY KEY CLUSTERED ([PlaneID] ASC)
);

