﻿namespace ManhPT_APIAssignment.API.Dtos
{
    public record ApiResponse(bool IsSuccess, string? Msg = null)
    {
        public static ApiResponse Success() => new(true, null);
        public static ApiResponse Fail(string? message) => new(false, message);

    }
    public record ApiResponse<TData>(bool IsSuccess, TData Data, string? Msg = null)
    {
        public static ApiResponse<TData> Success(TData data) => new(true, data, null);
        public static ApiResponse<TData> Fail(string? message) => new(false, default!, message);
    }
}
