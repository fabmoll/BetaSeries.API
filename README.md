[![BetaSeries.API MyGet Build Status](https://www.myget.org/BuildSource/Badge/fabmoll?identifier=f210c876-5f57-426b-9e01-4d86fe3a580b)](https://www.myget.org/)

# BetaSeries.API
Universal Windows 10 C# API pour [BetaSéries](http://www.betaseries.com "BetaSéries")

# Utilisation #
---
Pour pouvoir utiliser l'API, il est nécessaire de faire une demande de clé API via le [formulaire](http://www.betaseries.com/api/ "formulaire") de demande de clé développeur.

**Authentification**

    var memberService = new MemberService { ApiKey = "VOTRE_CLE_API", UserAgent = "VOTRE_USER_AGENT };
    var rootAuth = memberService.AuthASync("VOTRE_LOGIN", "VOTRE_MOT_DE_PASSE");
L'objet **rootAuth** contient la propriété **Token** qui vous sera utile lors de l'utilisation de l'API afin d'intéragir avec votre compte BetaSéries.

**Détail d'un épisode**

    var episodeService = new EpisodeService { ApiKey = "VOTRE_CLE_API", UserAgent = "VOTRE_USER_AGENT, Token = "VOTRE_TOKEN_UTILISATEUR" };
    var episode = episodeService.GetASync(episodeId);

**Projet de test**

Un projet de test existe afin de tester les différentes méthodes de l'API.

Avant de pouvoir tester l'API, vous devez remplacer le contenu du fichier **TestSettings.cs** afin d'utiliser votre clé API, votre user agent et votre token utilisateur.

    public static class TestSettings
	{
		public static string Token = "VOTRE_TOKEN_UTILISATEUR";
		public static string ApiKey = "VOTRE_CLE_API";
		public static string UserAgent = "VOTRE_USER_AGENT";
	}

# Contribution #
---
Pour contribuer au projet, il vous suffit de m'envoyer vos pull request :p

**Remarque importante**

La tabulation et l'indentation de mon éditeur ont une taille de 4 et les espaces sont remplacés par des tabulations.

Sous Visual Studio la combinaisons de touches CTRL+K+D vous permettra d'aligner le code et de remplacer les espaces en trop par des tabulations si nécessaire.


**Librairies utilisées**
---
L'API utilise les librairies suivantes :

- [Kulman.WPA81.BaseRestService](https://github.com/igorkulman/Kulman.WPA81.BaseRestService "Kulman.WPA81.BaseRestService")
- [Json.NET](http://www.newtonsoft.com/json "Json.NET")

**Clé API**
---
Afin de pouvoir utiliser l'API de BetaSéries vous devez faire la demande d'une clé : https://www.betaseries.com/api/
