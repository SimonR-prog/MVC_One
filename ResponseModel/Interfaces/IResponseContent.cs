﻿namespace ResponseModel.Interfaces
{
    public interface IResponseContent<T> : IResponse
    {
        T? Content { get; }
    }
}