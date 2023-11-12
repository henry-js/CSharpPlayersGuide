using Spectre.Console;

var gameDir = Path.Combine(Directory.GetCurrentDirectory(), "game");
if (!Directory.Exists(gameDir))
    Directory.CreateDirectory(gameDir);

var name = AnsiConsole.Ask<string>("Enter name:");

var gameFile = Path.Combine(gameDir, $"{name}.txt");
if (!File.Exists(gameFile))
{
    var stream = File.Create(gameFile);
    stream.Dispose();
}
if (!int.TryParse(File.ReadAllText(gameFile), out int score))
    score = 0;
AnsiConsole.WriteLine($"Current score: {score}. Press any key to play, press <Enter> to quit.");
while (Console.ReadKey().Key != ConsoleKey.Enter)
{
    AnsiConsole.Clear();
    AnsiConsole.WriteLine($"Player: {name}, Score: {score}");
    score += 1;
}

File.WriteAllText(gameFile, score.ToString());