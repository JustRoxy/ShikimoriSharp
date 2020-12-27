# Shikimori API .NET

[![Nuget](https://img.shields.io/nuget/v/ShikimoriSharp)](https://www.nuget.org/packages/ShikimoriSharp/)
![.NET Core](https://github.com/JustRoxy/ShikimoriSharp/workflows/.NET%20Core/badge.svg)

# API Documentation
https://shikimori.one/api/doc/1.0

# Tutorial

### Get Authorization Code or Access Token
https://shikimori.one/oauth

### ShikimoriClient

```csharp
var client = new ShikimoriSharp(logger, new ClientSettings("ClientName", "ClientID", "ClientSecret"));
```

```csharp
var token = client.Client.AuthorizationManager.GetAccessToken("authorizationCode"); //If you need to convert authorization code to access token
```

**Subscribe on token updates, probably you will need to store this somewhere**
```csharp
client.Client.OnNewToken += token => Console.WriteLine($"{token.Access_Token}:{token.RefreshToken}");
```

### Use Shikimori API v1
**Example of getting the entire anime list from profile**
```csharp
var token = new AccessToken
{
       Access_Token = access,
       RefreshToken = refresh
}
var myAnime = new List<Anime>(); 
for (int i = 1; ; i++)
{
     var page = await client.Animes.GetAnime(new AnimeRequestSettings
                {
                   page = i,
                   limit = 50,
                   mylist = MyList.completed
                }, token); //Token is important for identification of the user
      if(page.Length == 0) break;
      myAnime.AddRange(page);
}

```
**Example of getting related titles by name**
```csharp
var search = await client.Animes.GetAnime(new AnimeRequestSettings
                                        {
                                            search = "Detective Conan"
                                        });
var id = search.First().Id;
var conan = await client.Animes.GetAnimeById(id);
Console.WriteLine($"Anime {conan.Name}: {conan.Score}");
var related = await client.Animes.GetRelated(id);
Console.WriteLine($"\Related titles");
foreach (var rel in related)
{
      Console.Write(rel.RelationRussian);
      if(!(rel.Anime is null)) Console.WriteLine($" | Anime: {rel.Anime.Name}");
      if (!(rel.Manga is null)) Console.WriteLine($" | Manga: {rel.Manga.Name}");
      Console.WriteLine();
}
```
