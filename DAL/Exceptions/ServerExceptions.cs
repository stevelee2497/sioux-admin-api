using System;

namespace DAL.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message)
		{
		}
	}

	public class ConflictException : Exception
	{
		public ConflictException(string message) : base(message)
		{
		}
	}

	public class DataNotFoundException : Exception
	{
		public DataNotFoundException(string message) : base(message)
		{
		}
	}

	public class InternalServerErrorException : Exception
	{
		public InternalServerErrorException(string message) : base(message)
		{
		}
	}
}