namespace Application.Core
{
    public class Result<T>
    {
        public bool IsSuccsess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }

        public static Result<T> Succsess(T value) =>
            new Result<T>
            {
                IsSuccsess = true,
                Value = value
            };

        public static Result<T> Failure(string error) =>
            new Result<T>
            {
                IsSuccsess = false,
                Error = error
            };
    }
}