# Creating a project:

[project creation](https://cloud.google.com/resource-manager/docs/creating-managing-projects#gcloud)

Command in cloud shell:
gcloud projects create PROJECT_NAME
`PROJECT_NAME` - project name

======================================================================================

# Creating cloud repository

[repository managing](https://cloud.google.com/source-repositories/docs/quickstart?hl=en_US&_ga=2.251826126.676791970.1644443656-2048089208.1637833296&_gac=1.187078106.1644148771.Cj0KCQiAgP6PBhDmARIsAPWMq6kdEJaeIuF_8_53ciptJJScPhRySLoT1XfUlqr5wQCrVwM5W0EOrYkaAm04EALw_wcB).

Commands in cloud shell:
gcloud source repos create REPO_NAME
`REPO_NAME` - repository name

Command to get a list of repositories from google cloud in cloud shell:
gcloud source repos list

Commands to action (install before google cloud sdk on your machine) in local shell:
gcloud source repos clone REPO_NAME
git add .
git commit -m "..."
git push origin master

======================================================================================
# Creating VM with compute engine

Command in local shell:
gcloud compute instances create VM_NAME --image-project=debian-cloud --image-family=debian-10 --zone=europe-central2-a --hostname=HOST_NAME
`VM_NAME` - VM name  
`HOST_NAME` - host name for VM (is not necessary)

Link to VM tags from http server
Command in local shell:
gcloud compute instances add-tags VM_NAME --tags http-server,https-server
`VM_NAME` - VM name 

======================================================================================

# Creating SQL Instance
 
[Instance creating](https://cloud.google.com/sql/docs/mysql/create-instance#gcloud)  
[Regions](https://cloud.google.com/sql/docs/mysql/instance-settings#region-values)  
[Database versions](https://cloud.google.com/sql/docs/postgres/db-versions)  

Command to create in local shell:
gcloud sql instances create INSTANCE_NAME --database-version=POSTGRES_13 --cpu=1 --memory=3840MB --region=europe-central2
`INSTANCE_NAME` - SQL Instance name

Command to create DB in Instance in local shell:
gcloud sql databases create DATABASE_NAME --instance=INSTANCE_NAME
`DATABASE_NAME` - DB name

Command to update user's password in Instance in local shell:
gcloud sql users set-password postgres --host=INSTANCE_PUBLIC_IP --instance INSTANCE_NAME --password PASSWORD
`INSTANCE_PUBLIC_IP` - public ip SQL Instance (in google cloud SQL)

Command to add IP addresses (that can be connected to DB) in list (add ip of work machine + created VM in compute engine) in local shell: 
gcloud sql instances patch INSTANCE_NAME --authorized-networks=[ipAddres1,ipAddres2,...]
`INSTANCE_NAME` - SQL Instance name

Here it is needed to create appsettings.Production.json in project with new connection string to new instance and DB

======================================================================================

# Deploying .NET application in Compute Engine

Go to the Compute Engine in VM shell:

%%%%
Set up and setting necessary applications:
sudo apt install git

sudo apt update
sudo apt install wget

sudo apt install nginx
sudo apt install ufw

sudo ufw allow 'Nginx Full'
sudo service nginx start

Installing .NET 6:

wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install -y dotnet-sdk-6.0

sudo dotnet --version
%%% - run setup-environment.sh

Command to allow using in local shell:
gcloud compute firewall-rules create allow-80 --allow tcp:80

Git clone repository and deploy application (deploy-production.sh), create configuration for nginx

sudo service nginx restart

======================================================================================

# Setup fluentd

[Instance creating](https://cloud.google.com/logging/docs/agent/logging/installation#agent-version-debian-ubuntu)  

Setup log agent (DON'T WORK WITH debian 11) in VM shell:
curl -sSO https://dl.google.com/cloudagents/add-logging-agent-repo.sh
sudo bash add-logging-agent-repo.sh --also-install

======================================================================================

# Setting Developer Portal

Tab `Endpoints` in GC -> create developer portal

Command in local shell:
gcloud endpoints services deploy swagger.json
`swagger.json` - file with swagger specification of the site (NEEDED swagger V2.0 to work towh developer portal)

======================================================================================

# App engine

Creating App Engine in local shell:
gcloud app create --region=europe-central2

======================================================================================