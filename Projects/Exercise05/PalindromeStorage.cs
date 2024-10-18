namespace Exercise05;
public static class PalindromeStorage
{
    private static List<int> palindromeNumbers = new List<int>();

    public static void AddPalindromeNumber(int number)
    {
        palindromeNumbers.Add(number);
    }

    public static IEnumerable<int> GetPalindromeNumbers()
    {
        return palindromeNumbers;
    }
}

