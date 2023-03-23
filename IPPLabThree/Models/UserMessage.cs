namespace IPPLabThree.Models
{
    public class UserMessage
    {
        public ArrowType ArrowType { get; set; }

        public UserMessage() { ArrowType = ArrowType.ArrowLeft; }
        public UserMessage(ArrowType messageType) { ArrowType = messageType; }
    }
}