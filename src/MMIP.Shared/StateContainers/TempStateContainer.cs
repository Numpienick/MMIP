using MMIP.Shared.Entities;

namespace MMIP.Shared.StateContainers
{
    public class TempStateContainer
    {
        private static TempStateContainer _instance;

        public List<Phase> Phases { get; set; }
        public IQueryable<Challenge> Challenges { get; set; }
        public IQueryable<Comment> Comments { get; set; }

        public static TempStateContainer Instance()
        {
            if (_instance == null)
            {
                _instance = new TempStateContainer();
            }

            return _instance;
        }
    }
}
