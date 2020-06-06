# Shikimori API .NET

[![Nuget](https://img.shields.io/nuget/v/ShikimoriSharp)](https://www.nuget.org/packages/ShikimoriSharp/)
![.NET Core](https://github.com/JustRoxy/ShikimoriSharp/workflows/.NET%20Core/badge.svg)

# Документация API
https://shikimori.one/api/doc/1.0

# Туториал по использованию

### Получите Authorization Code, или Access Token
https://shikimori.one/oauth

### ShikimoriClient

```csharp
var client = new ShikimoriSharp(logger, new ClientSettings("ИмяКлиента", "IDКлиента", "СекретКлиента"));
```

```csharp
var token = client.Client.AuthorizationManager.GetAccessToken("authorizationCode"); //Если вам нужен Access Token из кода авторизации
```

**Подпишитсь на обновления токена, скорее всего будет для вас это будет важно**
```csharp
client.Client.OnNewToken += token => Console.WriteLine($"{token.Access_Token}:{token.RefreshToken}");
```

### Используйте Shikimori API v1
**Пример получения всего вашего аниме**
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
                }, token); //Важен токен, для идентификации пользователя
      if(page.Length == 0) break;
      myAnime.AddRange(page);
}

```
**Пример получения всех связанных тайтлов по названию**
```csharp
var search = await client.Animes.GetAnime(new AnimeRequestSettings
                                        {
                                            search = "Detective Conan"
                                        });
var id = search.First().Id;
var conan = await client.Animes.GetAnimeById(id);
Console.WriteLine($"Аниме {conan.Name}: {conan.Score}");
var related = await client.Animes.GetRelated(id);
Console.WriteLine($"\nСвязанные тайтлы");
foreach (var rel in related)
{
      Console.Write(rel.RelationRussian);
      if(!(rel.Anime is null)) Console.WriteLine($" | Аниме: {rel.Anime.Name}");
      if (!(rel.Manga is null)) Console.WriteLine($" | Манга: {rel.Manga.Name}");
      Console.WriteLine();
}
```
