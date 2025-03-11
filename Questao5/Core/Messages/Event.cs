using MediatR;
using System.Text.Json.Serialization;

namespace Questao5.Core.Messages
{
    public abstract class Event : INotification
    {
        [JsonIgnore]
        public string MessageType { get; protected set; }        

        protected Event()
        {
            MessageType = GetType().Name;
        }
    }
}
