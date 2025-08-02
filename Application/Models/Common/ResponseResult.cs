
namespace Application.Models.Common
{
    public class ResponseResult<T>
    {
        internal ResponseResult(bool succeeded, List<string> errors, T? model)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            Model = model;
        }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public T? Model { get; set; }
        public static ResponseResult<T> Success(T? model)
        {
            return new ResponseResult<T>(true, new List<string> { }, model);
        }
        public static ResponseResult<T> Failure(List<string> Errors, T? model)
        {
            return new ResponseResult<T>(false, Errors, model);
        }
    }
}
