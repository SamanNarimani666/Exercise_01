namespace Exercise06;
public static class PrimeNumberStorage
{
    private static List<int> primeNumbers = new List<int>();

    public static void AddPrimeNumber(int number)
    {
        primeNumbers.Add(number);
    }

    public static IEnumerable<int> GetPrimeNumbers()
    {
        return primeNumbers;
    }
}
