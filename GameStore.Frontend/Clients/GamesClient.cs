using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
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
        Name = "The Witcher 3: Wild Hunt",
        Genre = "RPG",
        Price = 29.99m,
        ReleasedDate = new DateOnly(2015, 5, 19)
    },
    new() {
        Id = 3,
        Name = "Cyberpunk 2077",
        Genre = "RPG",
        Price = 59.99m,
        ReleasedDate = new DateOnly(2020, 12, 10)
    },
    new() {
        Id = 4,
        Name = "Red Dead Redemption 2",
        Genre = "Adventure",
        Price = 49.99m,
        ReleasedDate = new DateOnly(2018, 10, 26)
    },
    new() {
        Id = 5,
        Name = "Minecraft",
        Genre = "Sandbox",
        Price = 26.95m,
        ReleasedDate = new DateOnly(2011, 11, 18)
    }
];
    public GameSummary[] GetGames() => [.. games];
}
