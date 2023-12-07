using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] phone = phoneNumber.Split("-");
        
        bool IsNewYork = phone[0] == "212";
        bool IsFake = phone[1] == "555";
        string LocalNumber = phone[2];

        return (IsNewYork, IsFake, LocalNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) => phoneNumberInfo.IsFake;
}