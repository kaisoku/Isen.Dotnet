Core SDK et runtime

#Preparatifs
`mkdir Isen.Dotnet`
`cd Isen.Dotnet`
`git init`
`touch readme.md`
code

##Creation de l'espace de travail
##Creation d'un projet console
`mkdir Isen.Dotnet.ConsoleApp`
`cd Isen.Dotnet.ConsoleApp`
`dotnet new console`
`dotnet run`

###Commit Git
Depuis la racine du projet
Etat des fichiers (non track): `git status`
Tracker les fichier : `git add .`
Commit :  `git commit -m "Initial commit"`

####Creation d'un projet librairie
Depuis le dossier racine
`mkdir Isen.Dotnet.Library`
`cd Isen.Dotnet.Library`
`dotnet new classlib`

##Ajout de la librairie en reference du projet console
Depuis le dossier du projet console:
Ajouter la reference library au projet console
`dotnet add reference ..\Isen.Dotnet.Library\Isen.Dotnet.Library\Isen.Dotnet.Library.csproj`
coder la classe Hello
Dans le program.cs, ajouter le using et appeler la classe greeting

## Creation d'une solution et ajout des projets
Depuis le dossier racine
`dotnet new sln`
Ajouter le projet librairie : `dotnet sln add Isen.Dotnet.Library\Isen.Dotnet.Library.csproj`
Ajouter le projet console: `dotnet sln add Isen.Dotnet.ConsoleApp\Isen.Dotnet.ConsoleApp.csproj`

##Commit Git
`git add .`
`git commit  - m "Console, lib, solution"`

#Ajout d'un projet de test
TDD= Test Driven Development
Depuis le dossier racine:
`mkdir Isen.Dotbet,Test`
`cd Isen.Dotnet.Test`
`dotnet new xunit`

#Ajout du projet a la solution(depuis le dossier racine)
`dotnet sln add Isen.Dotnet.Test\Isen.Dotnet.Test.csproj`

#Ajout le projet a la solution( depuis le dossier projet test):
Ajouter le projet librairie:
`dotnet add reference ..\Isen.Dotnet.library\Isen.Dotnet.Library.csproj`



