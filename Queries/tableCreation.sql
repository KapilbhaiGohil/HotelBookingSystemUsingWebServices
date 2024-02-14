CREATE TABLE [dbo].[user] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [Email]    VARCHAR (50) NOT NULL,
    [Password] NCHAR (50)   NOT NULL,
    [Phone]    VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Phone] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

CREATE TABLE [dbo].[room] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Type]     VARCHAR (50)  NOT NULL,
    [Desc]     VARCHAR (500) NOT NULL,
    [area]     NCHAR (50)    NOT NULL,
    [capasity] NUMERIC (1)   NOT NULL,
    [bedtype]  NCHAR (50)    NOT NULL,
    [price]    NUMERIC (18)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[reservation] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [checkin]        DATE          NOT NULL,
    [checkout]       DATE          NOT NULL,
    [amount]         INT           NOT NULL,
    [firstname]      VARCHAR (50)  NOT NULL,
    [lastname]       VARCHAR (50)  NOT NULL,
    [email]          VARCHAR (50)  NOT NULL,
    [phone]          VARCHAR (50)  NOT NULL,
    [specialRequest] VARCHAR (500) NOT NULL,
    [date]           DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[eachroom] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [RoomTypeId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_eachroom_ToTable] FOREIGN KEY ([RoomTypeId]) REFERENCES [dbo].[room] ([Id])
);

CREATE TABLE [dbo].[reservationeachroom] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [reservationid] INT        NOT NULL,
    [eachroomid]    INT        NOT NULL,
    [adult]         INT        NULL,
    [children]      INT        NULL,
    [price]         NCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_reservationeachroom_ToTable] FOREIGN KEY ([reservationid]) REFERENCES [dbo].[reservation] ([Id]),
    CONSTRAINT [FK_reservationeachroom_ToTable_1] FOREIGN KEY ([eachroomid]) REFERENCES [dbo].[eachroom] ([Id])
);

