using GameStore.Api.Endpoints;
using GameStore.Api.repositories;

var builder = WebApplication.CreateBuilder(args);

//Get Only 1 instance of request for entire life time of request
builder.Services.AddSingleton<IGamesRepo,InMemoGamesRepo>();

var app = builder.Build();

//call the gamesEndpoint.cs
app.MapGamesEndpoint();

app.Run();
