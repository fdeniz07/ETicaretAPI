namespace ETicaretAPI.Application.Exceptions
{
    public class UserCreateFailedException:Exception
    {
        public UserCreateFailedException():base()
        {
        }

        public UserCreateFailedException(string? message) : base("Kullanıcı oluşturulurken beklenmedik bir hatayla karşılaşıldı!")
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
