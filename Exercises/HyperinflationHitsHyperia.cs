using System;

public static class CentralBank
{
  public static string DisplayDenomination(long @base, long multiplier)
  {
    try
    {
      return checked(@base * multiplier).ToString();
    }
    catch (Exception)
    {
      return "*** Too Big ***";
    }
  }

  public static string DisplayGDP(float @base, float multiplier)
  {
    string result = checked(@base * multiplier).ToString();
    switch (result)
    {
      case "Infinity":
        return "*** Too Big ***";
      default:
        return result;
    }
  }

  public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
  {
    try
    {
      return checked(salaryBase * multiplier).ToString();
    }
    catch (Exception)
    {
      return "*** Much Too Big ***";
    }
  }
}