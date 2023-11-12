using Spectre.Console;

bool IsEven(int number) => number % 2 == 0;

bool IsPositive(int number) => number > 0;

bool IsMultipleOfTen(int number) => number % 10 == 0;

var answer = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
    .AddChoices([nameof(IsEven), nameof(IsPositive), nameof(IsMultipleOfTen)]));

Sieve sieve = answer switch
{
    nameof(IsEven) => new Sieve(x => x % 2 == 0),
    nameof(IsPositive) => new Sieve(IsPositive),
    nameof(IsMultipleOfTen) => new Sieve(IsMultipleOfTen),
    _ => throw new ArgumentOutOfRangeException(nameof(answer))
};

var valueToCheck = AnsiConsole.Ask<int>("Enter a number to check against");

string isOrIsnt = sieve.IsGood(valueToCheck) ? "is" : "is not";
string end = answer switch
{
    nameof(IsEven) => "even",
    nameof(IsPositive) => "positive",
    nameof(IsMultipleOfTen) => "a multiple of ten"
};

AnsiConsole.MarkupLineInterpolated($"Input value: {valueToCheck} [green]{isOrIsnt}[/] [blue]{end}[/]");

Console.ReadLine();