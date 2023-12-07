using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime d = DateTime.Parse(appointmentDateDescription);
        return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime currentDate = DateTime.Now;

        if (appointmentDate < currentDate) 
        {
            return true;
        }
        return false;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        if (appointmentDate.Hour >= 12 && appointmentDate.Hour < 18) 
        {
            return true;
        }
        return false;
    }

    public static string Description(DateTime appointmentDate)
    {
        bool isPm = appointmentDate.Hour > 12 && appointmentDate.Hour < 24 ? true : false;
        string date = appointmentDate.ToString("M/d/yyyy h:mm:ss");

        if (isPm)
        {
            return $"You have an appointment on {date} PM.";
        }

        return $"You have an appointment on {date} AM.";
    }

    public static DateTime AnniversaryDate()
    {
        int year = DateTime.Now.Year;
        return new DateTime(year, 9, 15, 0, 0, 0);
    }
}