using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string signal) => str.Split(signal)[1];

    public static string SubstringBetween(this string str, string fSignal, string sSignal)
    {
        int firstIndex = str.IndexOf(fSignal);
        int firstLen = fSignal.Length;
        int secondIndex = str.IndexOf(sSignal);
        int secondLen = sSignal.Length;

        int firstParam = firstIndex + firstLen;
        int secondParam = secondIndex - firstParam;
        
        return str.Substring(firstParam, secondParam);
    }
    
    public static string Message(this string str) => str.SubstringAfter(": ");

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}