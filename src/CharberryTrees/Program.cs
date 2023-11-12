var tree = new CharberryTree();
var notifier = new Notifier(tree);
var harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();

public class CharberryTree
{
    private Random _random = new();
    public bool Ripe { get; set; }
    public event EventHandler? Ripened;

    public void MaybeGrow()
    {
        if (_random.NextDouble() < 0.000_0001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke(this, EventArgs.Empty);
        }
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += Notify;
    }

    private void Notify(object? sender, EventArgs e)
    {
        Console.WriteLine("A charberry fruit has ripened!");
    }
}

public class Harvester
{
    public Harvester(CharberryTree tree)
    {
        tree.Ripened += Harvest;
    }

    private void Harvest(object? sender, EventArgs e)
    {
        if (sender is CharberryTree tree)
            tree.Ripe = false;
    }
}