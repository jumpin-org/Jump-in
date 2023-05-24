CREATE SCHEMA [admin]
GO

CREATE SCHEMA [auction]
GO

CREATE TABLE [admin].[Users] (
  [user_id] INT PRIMARY KEY IDENTITY(1, 1),
  [username] VARCHAR(50),
  [email] VARCHAR(100),
  [password] VARCHAR(100),
  [address] VARCHAR(200),
  [phone_number] VARCHAR(20)
)
GO

CREATE TABLE [admin].[Administrator] (
  [administrator_id] INT PRIMARY KEY,
  [user_id] INT
)
GO

CREATE TABLE [admin].[FicaStatus] (
  [fica_status_id] INT PRIMARY KEY,
  [fica_status_name] VARCHAR(50),
  [decription] VARCHAR(1000)
)
GO

CREATE TABLE [admin].[FicaInformation] (
  [fica_id] INT PRIMARY KEY,
  [document] varbinary(max),
  [fica_status_id] INT
)
GO

CREATE TABLE [admin].[Account] (
  [account_id] INT PRIMARY KEY,
  [user_id] INT,
  [fica_id] INT
)
GO

CREATE TABLE [auction].[AuctionStatus] (
  [auction_status_id] INT PRIMARY KEY,
  [auction_status_name] VARCHAR(50),
  [decription] VARCHAR(1000)
)
GO

CREATE TABLE [auction].[Auction] (
  [auction_id] INT PRIMARY KEY,
  [title] VARCHAR(100),
  [description] VARCHAR(500),
  [start_price] DECIMAL(10,2),
  [current_price] DECIMAL(10,2),
  [decrement] DECIMAL(10,2),
  [end_time] DATETIME,
  [seller_id] INT,
  [auction_status_id] INT
)
GO

CREATE TABLE [auction].[Bidder] (
  [bidder_id] INT PRIMARY KEY,
  [account_id] INT
)
GO

CREATE TABLE [auction].[Seller] (
  [seller_id] INT PRIMARY KEY,
  [account_id] INT
)
GO

CREATE TABLE [auction].[BidStatus] (
  [bid_status_id] INT PRIMARY KEY,
  [bid_status_name] VARCHAR(50),
  [decription] VARCHAR(1000)
)
GO

CREATE TABLE [auction].[Bid] (
  [bid_id] INT PRIMARY KEY,
  [auction_id] INT,
  [bidder_id] INT,
  [amount] DECIMAL(10,2),
  [bid_time] DATETIME,
  [bid_status_id] INT
)
GO

CREATE TABLE [auction].[Payment] (
  [payment_id] INT PRIMARY KEY,
  [bid_id] INT,
  [amount] DECIMAL(10,2),
  [payment_time] DATETIME,
  [proof_of_payment] varbinary(max)
)
GO

CREATE TABLE [auction].[Product] (
  [product_id] INT PRIMARY KEY,
  [auction_id] INT,
  [product_name] VARCHAR(50) NOT NULL,
  [product_number] VARCHAR(25) NOT NULL,
  [color] VARCHAR(15),
  [current_price] MONEY NOT NULL,
  [size] VARCHAR(5),
  [weight] DECIMAL(8,2),
  [discontinued_date] TIMESTAMP,
  [thumbnail_photo] varbinary(max),
  [thumbnail_photo_file_name] varchar(50),
  [modified_date] TIMESTAMP NOT NULL
)
GO

ALTER TABLE [admin].[Administrator] ADD FOREIGN KEY ([user_id]) REFERENCES [admin].[Users] ([user_id])
GO

ALTER TABLE [admin].[FicaInformation] ADD FOREIGN KEY ([fica_status_id]) REFERENCES [admin].[FicaStatus] ([fica_status_id])
GO

ALTER TABLE [admin].[Account] ADD FOREIGN KEY ([user_id]) REFERENCES [admin].[Users] ([user_id])
GO

ALTER TABLE [admin].[Account] ADD FOREIGN KEY ([fica_id]) REFERENCES [admin].[FicaInformation] ([fica_id])
GO

ALTER TABLE [auction].[Bidder] ADD FOREIGN KEY ([account_id]) REFERENCES [admin].[Account] ([account_id])
GO

ALTER TABLE [auction].[Seller] ADD FOREIGN KEY ([account_id]) REFERENCES [admin].[Account] ([account_id])
GO

ALTER TABLE [auction].[Auction] ADD FOREIGN KEY ([seller_id]) REFERENCES [auction].[Seller] ([seller_id])
GO

ALTER TABLE [auction].[Auction] ADD FOREIGN KEY ([auction_status_id]) REFERENCES [auction].[AuctionStatus] ([auction_status_id])
GO

ALTER TABLE [auction].[Bid] ADD FOREIGN KEY ([auction_id]) REFERENCES [auction].[Auction] ([auction_id])
GO

ALTER TABLE [auction].[Bid] ADD FOREIGN KEY ([bidder_id]) REFERENCES [auction].[Bidder] ([bidder_id])
GO

ALTER TABLE [auction].[Bid] ADD FOREIGN KEY ([bid_status_id]) REFERENCES [auction].[BidStatus] ([bid_status_id])
GO

ALTER TABLE [auction].[Payment] ADD FOREIGN KEY ([bid_id]) REFERENCES [auction].[Bid] ([bid_id])
GO

ALTER TABLE [auction].[Product] ADD FOREIGN KEY ([auction_id]) REFERENCES [auction].[Auction] ([auction_id])
GO
