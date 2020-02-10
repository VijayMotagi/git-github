Create Table [dbo].[RegistrationTable]
(
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[EmailId] NVARCHAR(50) NOT NULL,
	[MobileNumber] bigint NOT NULL,
	[UserName] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[ConfirmPassword] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	[Age] int	NOT NULL,
	[Gender] NVARCHAR(10) NOT NULL,
	[Country] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([MObileNumber] ASC)
);

Select * from RegistrationTable
