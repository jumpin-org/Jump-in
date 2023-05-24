echo off
ECHO ------------------
ECHO ADD MIGRATION
ECHO ------------------
ECHO.
ECHO Choose project:
ECHO.
ECHO 1 - Admin
ECHO 2 - Auction
ECHO.
set /p projectNumber="ANSWER: "

cd ..\..\Database\JumpIn.Database.Migrations

if %projectNumber%==1 GOTO Admin
if %projectNumber%==2 GOTO Auction
GOTO Error


:Admin

set contextName=AdminContext

cd Admin
set namespace=JumpIn.Database.Migrations.Admin

GOTO Migration


:Auction

ECHO.
ECHO Choose context:
ECHO.
ECHO 1 - AdminContext
ECHO 2 - AuctionCaseContext
ECHO.
set /p contextNumber="ANSWER: "

cd Auction

if %contextNumber%==1 (GOTO SetAdminContext) else if %contextNumber%==2 (GOTO SetAuctionCaseContext) else (GOTO Error)


:SetAdminContext


set contextName=AdminContext
set namespace=JumpIn.Database.Migrations.Auction

GOTO Migration


:SetAuctionCaseContext

set contextName=AuctionCaseContext
set namespace=JumpIn.Database.Migrations.Admin

GOTO Migration



:Migration

set projectPath=../JumpIn.Database.Migrations.csproj

set /p migrationName="Type migration name: "

ECHO Please review migration command below:
ECHO.
ECHO "set ASPNETCORE_ENVIRONMENT=Development&& dotnet ef migrations add %migrationName% -s %projectPath% --namespace %namespace% --context %contextName% & set ASPNETCORE_ENVIRONMENT="
ECHO.
ECHO Proceed if this is correct, otherwise close this window now
pause

set ASPNETCORE_ENVIRONMENT=Development&& dotnet ef migrations add %migrationName% -s %projectPath% --namespace %namespace% --context %contextName% & set ASPNETCORE_ENVIRONMENT=

GOTO End


:Error

ECHO An error occured, please try again.
GOTO End


:End

pause

