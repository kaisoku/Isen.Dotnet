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

#Commit Git
`git add .`
`git commit -m "Test Project"`

##Push du projet GitHub sur un repos distant

Creer un projet sur le serveur Git de votre choix( GitHub, GitLab,..)
L'url de mon repos
https://github.com/kaisoku/Isen.Dotnet.git

`git remote add origin https://github.com/kaisoku/Isen.Dotnet.git`
`git push -u origin master`

#Ajout d'un tag git
Creer le tag dans le repos local
`git tag v0.1`
Pusher le tag dans le remote repo
`git push origin v0.1`

#Ajout d'un modele
Dans le projet Library
Creer un dossier Models/Implementation
Creer une classe Person:
    Id(int)
    Name(string)
    FirstName(string)
    LastName(string)
    BirthDate(DateTime)
Creer une classe City:
    Id(int)
    Name(string)

#Refactoring : extraction d'un BaseModel
Les classes Person et City ont une partie de leur logique commune.
Extraire ce qui est commun dans une classe abstraite

#Ajout  Repositories
##CityRepositorie
A la racine du projet Library : creer un dossier Repositories\InMemory
Ajouter une classe InMemoryCityRepository
Extraire l'interface de ce repo dans `Repositories/Interfaces/IInMemoryCityRepository.cs`  

## Refactoring interface : extraire IBaseRepository
Déplacer les 3 méthodes de l'interface vers IBaseRepository  

## Refactoring Repository
* Créer la classe abstraite Repositories/Base/_BaseRepository.cs  
* Déplacer la logique de CityReposiory vers cette classe

##Appliquer au modele Person
Dupliquer ICityRepository vers IPersonRepository et adapter ce qui doit l'etre
Dupliquer InMemoryCityRepository vers InMemoryPersonRepository