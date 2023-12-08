using System;

public static class SimpleCalculator
{
  public static string Calculate(int operand1, int operand2, string operation)
  {
    switch (operation)
    {
      case "+":
        return $"{operand1} + {operand2} = {SimpleOperation.Addition(operand1, operand2)}";
      case "*":
        return $"{operand1} * {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}"; ;
      case "/" when operand2 != 0:
        return $"{operand1} / {operand2} = {SimpleOperation.Division(operand1, operand2)}";
      case "":
        throw new ArgumentException();
      case null:
        throw new ArgumentNullException();
      default:
        if (operand2 == 0) return "Division by zero is not allowed.";
        throw new ArgumentOutOfRangeException();
    }
  }
}

public static class SimpleOperation
{
  public static int Division(int operand1, int operand2)
  {
    return operand1 / operand2;
  }

  public static int Multiplication(int operand1, int operand2)
  {
    return operand1 * operand2;
  }

  public static int Addition(int operand1, int operand2)
  {
    return operand1 + operand2;
  }
}