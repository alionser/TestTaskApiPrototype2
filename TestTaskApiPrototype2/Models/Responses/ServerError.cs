namespace TestTaskApiPrototype2.Models.Responses
{
    public class ServerError // или структурой? что с DataContract?
    {
        public int Code { get; set; } = 400;
        public string Key { get; set; } //not nullable?
        public string Message { get; set; }

        public ServerError(int code, string key, string message) //TODO: оптимизировать констурторы цепочкой
        {
            Code = code;
            Key = key;
            Message = message;
        }

        public ServerError(string key, string message)
        {
            Key = key;
            Message = message;
        }


    }
}