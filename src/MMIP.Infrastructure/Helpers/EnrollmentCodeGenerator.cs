namespace MMIP.Infrastructure.Helpers;

internal static class EnrollmentCodeGenerator
{
    private const int length = 8;

    public static string GenerateEnrollmentCode()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(
            Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()
        );
    }
}
