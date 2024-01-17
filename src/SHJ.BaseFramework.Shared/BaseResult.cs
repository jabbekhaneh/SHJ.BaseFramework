using System;

namespace SHJ.BaseFramework.Shared;

public class BaseResult
{
    public bool IsSuccess { get; private set; } = true;
    public int Status { get; private set; }
    public object? Result { get; private set; }
    public List<string> Messages { get; private set; } = new();
    public void SetData(object result) => Result = result;
    public void ClearMessages() => Messages.Clear();
    public void AddMessage(string error) => Messages.Add(error);
    public void AddMessages(IEnumerable<string> errors) => Messages.AddRange(errors);
    public void SetStatus(int status) => this.Status = status;
    public bool IsValid() => (Messages.Count() > 0 ? false : true);
}
public class BaseResult<TResult>
{
    public BaseResult()
    {

    }
    public TResult? Result { get; private set; }

    public bool IsSuccess { get; private set; } = true;
    public int Status { get; private set; }
    public List<string> Messages { get; private set; } = new();
    public void ClearMessages() => Messages.Clear();
    public void AddMessage(string error) => Messages.Add(error);
    public void AddMessages(IEnumerable<string> errors) => Messages.AddRange(errors);
    public void SetStatus(int status) => this.Status = status;
    public bool IsValid() => (Messages.Count() > 0 ? false : true);

    public static BaseResult<TResult> Build(TResult result)
    {
        return new BaseResult<TResult> { IsSuccess = true, Result = result };
    }

    public static BaseResult<TResult> BuildFailure(List<string> message)
    {
        return new BaseResult<TResult> { IsSuccess = false, Messages = message };
    }


}
