@echo off

SET DIR=%~d0%~p0%

SET database.name="MMDBServiceFaker"
SET sql.files.directory="%DIR%..\db"
SET server.database="(local)"
SET repository.path="http://roundhouse.googlecode.com/svn"SET environment="LOCAL"

"%DIR%Console\rh.exe" /d=%database.name% /f=%sql.files.directory% /s=%server.database% /env=%environment% /simple

pause