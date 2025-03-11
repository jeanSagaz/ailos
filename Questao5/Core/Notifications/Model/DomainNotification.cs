namespace Questao5.Core.Notifications.Model
{
    public class DomainNotification
    {
        public string? Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string value, string? key = null)
        {
            Key = key;
            Value = value;
        }
    }
}
