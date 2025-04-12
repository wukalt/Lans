namespace Lans.Core.Convertors;

public static class FixedString
{
    public static string FixEmailString(string email) => email.Trim().ToLower();
}
