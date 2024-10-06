using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    private readonly List<GameSummary> games =
[
    new() {
        Id = 1,
        Name = "GTA San Andreas",
        Genre = "Adventure",
        Price = 19.99m,
        ReleasedDate = new DateOnly(2004, 9, 9)
    },
    new() {
        Id = 2,
        Name = "The Witcher 3",
        Genre = "Shooter",
        Price = 29.99m,
        ReleasedDate = new DateOnly(2015, 5, 19)
    },
    new() {
        Id = 3,
        Name = "Cyberpunk",
        Genre = "Fighting",
        Price = 59.99m,
        ReleasedDate = new DateOnly(2020, 12, 10)
    },
    new() {
        Id = 4,
        Name = "Red Dead Redemption 2",
        Genre = "Shooter",
        Price = 49.99m,
        ReleasedDate = new DateOnly(2018, 10, 26)
    },
    new() {
        Id = 5,
        Name = "Minecraft",
        Genre = "Adventure",
        Price = 26.95m,
        ReleasedDate = new DateOnly(2011, 11, 18)
    }
];
    private readonly Genre[] genres = new GenresClient(httpClient).GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            // There was a bug that i fixed
            Genre = genre.Name,
            Price = game.Price,
            ReleasedDate = game.ReleasedDate
        };

        games.Add(gameSummary);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(
            genre.Name, game.Genre,
            StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleasedDate = game.ReleasedDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleasedDate = updatedGame.ReleasedDate;
    }
    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game); // validation of null
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var genre = genres.Single(genre => genre.Id == int.Parse(id));
        return genre;
    }
}
