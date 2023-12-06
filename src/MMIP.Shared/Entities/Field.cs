namespace MMIP.Shared.Entities
{
    public class Field : BaseEntity
    {
        private string[] _requiredFields;

        public string[] RequiredFields
        {
            get => _requiredFields;
            set => _requiredFields = value;
        }
    }
}
