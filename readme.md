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
Dupliquer InMemoryCityRepository afin de creer InMemoryPersonRepository

##CRUD
*C = Create
*R = Read
*U = Update
*D = Delete

##Ajout du Delete
Dans `IBaseRepository` et `BaseRepository<T>`,
Ajouter 2 methodes:
Delete(int Id)
Delete(T Model)
Ajouter les modeles `DeleteRange` suivantes:
DeleteRange(IEnumerable<T> models)
    usage: `repo.DeleteRange(new List<T> {p1,p2,p3});`
DeleteRange(params T[] models)
    usage : `repo.DeleteRange(p1,p2,p3)`

##Ajout de l'update
Au niveau du BaseModel, ajouter une propriete `IsNew`
Dans BaseInMemoryRepository ajouter une methode `NewId()`,qui va recuperer le prochain id disponible..
Dans `IBaseRepository` ajouter la methode void `Update(t models`);
Ajouter la methode void `Update(T models)` abstraite dans `BaseRepository`
Dans `BaseInMemoryRepository` overrider et implementer la methode Update

Ajouter les modeles `UpdateRange` suivantes dans `IBaseREpository` et `BaseRepository`
DeleteRange(IEnumerable<T> models)
    usage: `repo.UpdateRange(new List<T> {p1,p2,p3});`
DeleteRange(params T[] models)
    usage : `repo.UpdateRange(p1,p2,p3)`

##Projet Asp.Net core MVC
##Creation du projet
Creation du dossier projet depuis le dossier racine:
`mkdir Isen.Dotnet.Web && cd Isen.Dotnet.Web`
Ajouter un projet web de type MVC
`dotnet new mvc`
Referencer la librairie :
`dotnet add reference ..\Isen.Dotnet.Library\Isen.Dotnet.Library.csproj`
Ajouter le projet web a la solution (depuis la racine de la solution)
`dotnet sln add Isen.Dotnet.Web\Isen.Dotnet.Web.csproj`
Compiler  /executer (dans le dossier Isen.Dotnet.Web)
`dotnet run`
Ouvrir le navigateur: `http:localhost:5000`

##Decouvrir et nettoyer la vue
Localiser les fichiers qui correspondent aux actions Index, About, et Contact de la vue home
Vider ces vues
Ecrire le nom et l'url de la vue dans chacune des 3 actions

##Configurer la minification js et css
A la racine du projet web, il y a un fichier bundleconfig.json
Pour que la minification se fasse au build/run(depuis le dossier web):
`dotnet add package BuildBundlerMinifier`

##Elements de syntaxe Razor (moteur de templating)

Dans Home/Index.cshtml, creer une liste C# des URL.
Iterer pour afficher ces URL dans la grid Bootstrap.
Pour afficher les erreurs cshtml detaillees
`set ASPNETCORE_ENVIRONMENT=Development` puis `dotnet run`
Pour revenir au mode production
`set ASPNETCORE_ENVIRONMENT=Production` puis `dotnet run`

##Vue imbriquees / injections de vue
`Views/Shared/_layout.cshtml` est le template de toutes les pages.
Les actions sont injectes au niveau de `@RenderBody`

##EXtraire le footer
Creer dans le dossier `Views/shared` un fichier `_Footer.cshtml`
Localiser le contenu du footer dans `Layout` et le couper/coller vers _Footer.cshtml
Remplacer par un appel a ce footer avec `@Html.Partial("_Footer")`.

##Extraire le menu
Creer dans `Views/Shared` un fichier `_Nav.cshtml`
Identifier le html correspondant au menu bootstrap
Deplacer vers `_Nav.cshtml`
Injecter `_Nav` dans `_Layout`
Personnaliser le "nom" de l'appli qui fait office de Logo.

##Vues particulieres et conventions
###_layout & ViewStart
`Layout` n'est pas appelée par convention. Elle est appelée par `ViewStart.cshtml`
`ViewStart` est appelée par convention de nommage, avant chaque chargement de vue.
Ajouter du contenu dans `ViewStart` et voir où il tombe.

##ViewImports

ViewImports permet de regrouper des `@using` utilisés par le C# embarqué dans les vues.

##Layout alternatif.

Créer un nouveau fichier de Layout (dupliquer _Layout et l'appeler _LayoutEmpty.cshtml).
Conserver la structure HTML, les imports CSS et JS, mais retirer toute la mise en forme et le menu.
Modifier la vue About afin qu'elle utilise _LayoutEmpty.


##Manipulation du menu Bootstrap

Dans le fichier `_Nav.cshtml`, ajouter les éléments suivants (en dropdown) :  

Villes
    Toutes...
    Ajouter... Ne pas mettre de lien pour l'instant, mettre # à la place des liens.
    Adapter un menu issu du site Bootstrap 3.3 (https://getbootstrap.com/docs/3.3/).

##Ajout d'une vue et d'un conteneur city

#Mettre a jour le menu
Dans `_Nav.cshtml`, adapter les liens à partir de ce qui est fait pour les autres.

#Ajouter une vue cshtml pour la liste

Dans Views, créer un dossier `City`.
Dans le dossier City, créer `Index.cshtml` (ou dupliquer le Index de Home).

##Maquetter un tableau

Dans `Views/City/Index.cshtml`, créer un tableau html avec le design bootstrap.  


##Injecter les données

Dans le controller, ajouter un champ référence vers `ICityController`.
Dans l'action Index, envoyer la liste des villes.
Dans la vue, indiquer que le `Model` est du type `IEnumerable<City>`.
Faire boucler la ligne du tableau sur le Model.
Dans `Startup.cs`, méthode `ConfigureServices`, indiquer le binding entre `ICityRepository` et `InMemoryCityRepository` dans le container IoC (injection de dépendances).  


##Vue détail

Dans le controller, ajouter une méthode `Detail`.
Créer la vue `Views/City/Detail.cshtml`.
Coder une maquette html de formulaire d'édition.
Dans le controller, méthode Detail(id), utiliser le repository pour récupérer la ville demandée et l'envoyer vers la vue.
Dans la vue Detail.cshtml, préciser le type du modèle (City), et injecter les données dans le form.
Dans le controleur, ajouter une surcharge de Detail, avec City en paramètre, passé en Http POST.  

##Logging