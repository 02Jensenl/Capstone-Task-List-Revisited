CREATE TABLE [dbo].[ToDoItem] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (40)  NULL,
    [DueDate]     DATE           NOT NULL,
    [Complete]    BIT            NOT NULL,
    [UserId]      NVARCHAR (450) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

