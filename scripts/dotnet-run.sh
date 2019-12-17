#!/bin/bash
export ASPNETCORE_ENVIRONMENT=local
cd src/S3.Services.Notification
dotnet run --no-restore