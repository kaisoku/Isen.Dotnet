Core SDK et runtime

#Preparatifs
mkdir Isen.Dotnet
cd Isen.Dotnet
git init
touch readme.md
code

##Creation de l'espace de travail
##Creation d'un projet console
mkdir Isen.Dotnet.ConsoleApp
cd Isen.Dotnet.ConsoleApp
dotnet new console
dotnet run

###Commit Git
Depuis la racine du projet
Etat des fichiers (non track): git status
Tracker les fichier : git add .
Commit :  git commit -m

####Creation d'un projet librairie
Depuis le dossier racine
mkdir Isen.Dotnet.Library
cd Isen.Dotnet.Library
dotnet new classlib

##Ajouter la 
Depuis le dossier du projet console:
dotnet add reference ..Isen.Dotnet.Library\Isen.Dotnet.Library\Isen.Dotnet.Library.csproj

