using Spectre.Console;
using ThePotionMastersOfPattren;

var potion = Potion.Water;
var ingredientSelector = new SelectionPrompt<Ingredient>()
    .AddChoices(Enum.GetValues<Ingredient>())
    .Title("Select an ingredient");
potion = Potion.Water;
bool potionIsDone = false;
do
{

    AnsiConsole.WriteLine($"You currently have a {potion} potion");
    var ingredient = AnsiConsole.Prompt(ingredientSelector);

    AnsiConsole.WriteLine($"Adding {ingredient} to your {potion}");
    potion = AddIngredient(potion, ingredient);
    Console.Clear();

    if (potion is Potion.Ruined)
    {
        AnsiConsole.WriteLine("Potion is ruined... Starting over with water");
        potion = Potion.Water;
        potionIsDone = false;
        Thread.Sleep(2000);
    }
    else
    {
        AnsiConsole.WriteLine($"You now have a {potion} potion.");
        potionIsDone = AnsiConsole.Confirm("Stop?");
    }

}
while (!potionIsDone);

Potion AddIngredient(Potion potion, Ingredient ingredient) => (potion, ingredient) switch
{
    (Potion.Water, Ingredient.Stardust) => Potion.Elixir,
    (Potion.Elixir, Ingredient.SnakeVenom) => Potion.Posion,
    (Potion.Elixir, Ingredient.DragonBreath) => Potion.Flying,
    (Potion.Elixir, Ingredient.ShadowGlass) => Potion.Invisibility,
    (Potion.Elixir, Ingredient.EyeshineGem) => Potion.NightSight,
    (Potion.NightSight, Ingredient.ShadowGlass) => Potion.CloudyBrew,
    (Potion.Invisibility, Ingredient.EyeshineGem) => Potion.CloudyBrew,
    (Potion.CloudyBrew, Ingredient.Stardust) => Potion.Wraith,
    _ => Potion.Ruined
};