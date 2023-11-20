using System.ComponentModel;

namespace Shared.Enums
{
    public enum Visibility
    {
        [Description("Zichtbaar voor iedereen")]
        VisibleToAll,

        [Description("Zichtbaar voor werknemers en ingelogde gebruikers")]
        VisibleToLoggedIn,

        [Description("Zichtbaar voor alleen werknemers")]
        VisibleToEmployees
    }
}
