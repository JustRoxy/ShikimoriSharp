# Shikimori API .NET

[![Nuget](https://img.shields.io/nuget/v/ShikimoriSharp)](https://www.nuget.org/packages/ShikimoriSharp/)
![.NET Core](https://github.com/JustRoxy/ShikimoriSharp/workflows/.NET%20Core/badge.svg)

# API Documentation
https://shikimori.one/api/doc/1.0

### OAUTH stuff
https://shikimori.one/oauth

# Examples

### ShikimoriClient

```csharp
var client = new ShikimoriSharp(logger, new ClientSettings("ClientName", "ClientID", "ClientSecret"));
```

```csharp
var token = client.Client.AuthorizationManager.GetAccessToken("authorizationCode"); //If you need to convert authorization code to access token
```

**Subscribe on token updates, you will probably need to store this somewhere**
```csharp
client.Client.OnNewToken += token => Console.WriteLine($"{token.Access_Token}:{token.RefreshToken}");
```

### Use Shikimori API v1

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
