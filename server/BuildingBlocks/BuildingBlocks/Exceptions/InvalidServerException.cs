﻿

namespace BuildingBlocks.Exceptions
{
    public class InvalidServerException : Exception
    {
        public string? Details { get; }
        public InvalidServerException(string message) : base(message) { }
        public InvalidServerException(string message, string details) : base(message)
        {
            Details = details ?? string.Empty;
        }
    }
}
