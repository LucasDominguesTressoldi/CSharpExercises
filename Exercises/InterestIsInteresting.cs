using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0) return 3.213f;
        if (balance < 1000) return 0.5f;
        if (balance < 5000) return 1.621f;
        return 2.475f;
    }

    public static decimal Interest(decimal balance)
    {
        return ((1 + ((decimal)InterestRate(balance) / 100)) * balance) - balance;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return Interest(balance) + balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int daysUntilDesiredBalance = 0;
        do
        {
            balance = AnnualBalanceUpdate(balance);
            ++daysUntilDesiredBalance;
        } while (balance < targetBalance);
        return daysUntilDesiredBalance;
    }
}