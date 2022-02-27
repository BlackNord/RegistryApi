#!/bin/bash

sudo dotnet publish --configuration Release -p:ASPNETCORE_ENVIRONMENT=Production -o:/var/www/registry-api

sudo cp ./DeployFiles/default /etc/nginx/sites-available/

sudo cp ./DeployFiles/registry-api.service /etc/systemd/system/

sudo systemctl enable registry-api.service
sudo systemctl start registry-api.service
sudo systemctl status registry-api.service

