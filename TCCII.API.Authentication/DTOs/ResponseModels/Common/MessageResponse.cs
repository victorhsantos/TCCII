using TCCII.Deputados.API.Messagens;

namespace TCCII.Deputados.API.DTOs.ResponseModels.Common
{
    public class MessageResponse
    {
        public int Code { get; private set; }
        public string Message { get; private set; }

        public static MessageResponse Success(MessageInstanceSuccess instanceSuccess) =>
            new MessageResponse { Code = (int)instanceSuccess, Message = instanceSuccess.GetDescription() };

        public static MessageResponse Write(string message) =>
            new MessageResponse { Message = message };
    }
}
