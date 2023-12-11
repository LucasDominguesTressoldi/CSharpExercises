using System;
using System.Globalization;

class WeighingMachine
{
  public int Precision { get; }

  public double TareAdjustment { get; set; } = 5.0;

  private double _weight;
  public double Weight
  {
    get { return _weight; }
    set
    {
      if (value >= 0)
        _weight = value;
      else
        throw new ArgumentOutOfRangeException();
    }
  }

  public string DisplayWeight
  {
    get
    {
      string roundedWeight = (this.Weight - this.TareAdjustment).ToString($"F{this.Precision}");
      return $"{roundedWeight} kg";
    }
  }

  public WeighingMachine(int precision) => this.Precision = precision;
}