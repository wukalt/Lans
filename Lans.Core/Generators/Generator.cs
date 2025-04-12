namespace Lans.Core.Generators;

public static class Generator
{
    public static string GenerateActivationCode() => Guid.NewGuid().ToString().Replace("-", "");
}
