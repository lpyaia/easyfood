using System.Runtime.Serialization;

namespace Easyfood.Partners.Domain.Exception
{
    [Serializable]
    public class DomainException : System.Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}