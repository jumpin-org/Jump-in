IF DB_ID('JumpIn') IS NULL
BEGIN
    -- Database does not exist, create it or perform necessary actions
    CREATE DATABASE JumpIn;
END
GO
