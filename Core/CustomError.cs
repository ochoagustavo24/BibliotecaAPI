namespace BibliotecaAPI.Core
{
    public class CustomError
    {
        // Codigo del error
        public int StatusCode;

        // Mensaje del error
        public string Message;

        // Campo con el error
        public string Field;

        /**
         * Constructor de la clase
         ***/
        public CustomError(int statusCode, string message, string field)
        {
            StatusCode = statusCode;
            Message = message;
            Field = field;
        }
    }
}
