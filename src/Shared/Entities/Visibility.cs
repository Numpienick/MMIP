namespace Shared.Entities
{
    public class Visibility
    {
        public int Id { get; set; }
        public string VisibleTo { get; set; }

        public Visibility(int id, string visibleTo)
        {
            Id = id;
            VisibleTo = visibleTo;
        }

        public static Visibility VisibleForAll()
        {
            return new Visibility(0, "Zichtbaar voor iedereen");
        }

        public static Visibility VisibleForLoggedin()
        {
            return new Visibility(1, "Zichtbaar voor werknemers en ingelogde gebruikers");
        }

        public static Visibility VisibleForEmployees()
        {
            return new Visibility(2, "Zichtbaar voor alleen werknemers");
        }
    }
}
