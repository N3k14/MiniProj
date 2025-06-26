using SharedKernel;

namespace WebApi.Extensions;

public static class ResultExtensions 
{
    public static IResult Match(
        this Result result,
        Func<IResult> onSuccess,
        Func<Result, IResult> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    public static IResult Match<TIn>(
        this Result<TIn> result,
        Func<TIn, IResult> onSuccess,
        Func<Result<TIn>, IResult> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }
}