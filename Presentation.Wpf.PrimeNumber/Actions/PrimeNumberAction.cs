namespace Presentation.Wpf.PrimeNumber.Actions
{
    public class PrimeNumberAction : IPrimeNumberAction
    {
        public bool IsPrimeNumber(int value)
        {
            if (value >= 2)
            {
                for (var i = 2; i < value; i++)
                {
                    for (var n = i; n < value; n++)
                    {
                        if (n * i == value)
                        {
                            return false;
                        }
                        else if (n * i > value)
                        {
                            break;
                        }

                    }

                }

                return true;
            }

            return false;
        }

        public bool IsPrimeNumberImproved(int value)
        {
            if (value >= 2)
            {
                for (var i = 2; i < value; i++)
                {
                    if (value % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
