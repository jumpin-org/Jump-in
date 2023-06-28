IF DB_ID('JumpInDev') IS NULL
BEGIN
    -- Database does not exist, create it or perform necessary actions
    CREATE DATABASE JumpInDev;
END
GO
