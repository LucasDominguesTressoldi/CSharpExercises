using System;
using System.Globalization;

public enum Location
{
  NewYork = 4,
  London = 1,
  Paris = 2
}

public enum AlertLevel
{
  Early = -1,
  Standard = -105,
  Late = -30
}

public static class Appointment
{
  public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc;

  public static DateTime Schedule(string appointmentDateDescription, Location location)
  {
    string[] date = appointmentDateDescription.Split(" ")[0].Split("/");
    string[] hour = appointmentDateDescription.Split(" ")[1].Split(":");

    int year = int.Parse(date[2]);
    int month = int.Parse(date[0]);
    int day = int.Parse(date[1]);

    int _hour = location == Location.NewYork ? int.Parse(hour[0]) + (int)location : int.Parse(hour[0]) - (int)location;
    int min = int.Parse(hour[1]);
    int sec = int.Parse(hour[2]);

    return ShowLocalTime(new DateTime(year, month, day, _hour, min, sec));
  }

  public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
  {
    switch (alertLevel)
    {
      case AlertLevel.Early:
        appointment = appointment.AddDays((int)alertLevel);
        return appointment;
      case AlertLevel.Standard:
        appointment = appointment.AddMinutes((int)alertLevel);
        return appointment;
      default:
        appointment = appointment.AddMinutes((int)alertLevel);
        return appointment;
    }
  }

  public static bool HasDaylightSavingChanged(DateTime dt, Location location)
  {
    TimeZoneInfo timezone = location switch
    {
      Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
      Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"),
      Location.London => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
      _ => throw new ArgumentException(),
    };
    if (timezone.IsDaylightSavingTime(dt.AddDays(-7)) == true && timezone.IsDaylightSavingTime(dt) == true)
      return false;
    else if (timezone.IsDaylightSavingTime(dt.AddDays(-7)) == false && timezone.IsDaylightSavingTime(dt) == false)
      return false;
    else
      return true;
  }

  public static DateTime NormalizeDateTime(string dtStr, Location location)
  {
    try
    {
      switch (location)
      {
        case Location.NewYork:
          return DateTime.Parse(dtStr, new CultureInfo("en-US"));
        case Location.London:
          return DateTime.Parse(dtStr, new CultureInfo("en-GB"));
        default:
          return DateTime.Parse(dtStr, new CultureInfo("fr-FR"));
      }
    }
    catch (Exception)
    {
      return DateTime.MinValue;
    }
  }
}