CREATE TABLE [dbo].[Occurrence] (
    [id_occurrence]  VARCHAR (100) NOT NULL,
    [date]           VARCHAR (20)  NOT NULL,
    [airplane_model] VARCHAR (50)  NOT NULL,
    [registration]   VARCHAR (20)  NULL,
    [operator]       VARCHAR (100) NOT NULL,
    [fatalities]     INT           NOT NULL,
    [location]       VARCHAR (30)  NOT NULL,
    [flag_img]       INT           NULL,
    [category]       VARCHAR (5)   NOT NULL,
    PRIMARY KEY CLUSTERED ([id_occurrence] ASC)
);

