namespace Presentation.Wpf.PrimeNumber.Actions
{
    public interface IPrimeNumberAction
    {
        bool IsPrimeNumber(int value);

        bool IsPrimeNumberImproved(int value);
    }
}
