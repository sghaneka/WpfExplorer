CREATE TABLE [SalesLT].[StatesReference]
(
	[State] VARCHAR(50) NOT NULL,
	[Country] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_StatesReference] PRIMARY KEY CLUSTERED ([State],[Country] ASC)
)
