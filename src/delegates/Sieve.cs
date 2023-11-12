public class Sieve
{
    private readonly Predicate<int> predicate;

    public Sieve(Predicate<int> predicate)
    {
        this.predicate = predicate;
    }

    public bool IsGood(int number)
    {
        return predicate.Invoke(number);
    }
}