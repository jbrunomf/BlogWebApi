﻿namespace BlogWebApi.ViewModels
{
    public class ResultViewModel<T>
    {
        public ResultViewModel(T data, List<string> errors)
        {
            Errors = errors;
            Data = data;
        }

        public ResultViewModel(List<string> errors)
        {
            Errors = errors;
        }

        public ResultViewModel(string error)
        {
            Errors.Add(error);
        }

        public ResultViewModel(T data)
        {
            Data = data;
        }

        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}
