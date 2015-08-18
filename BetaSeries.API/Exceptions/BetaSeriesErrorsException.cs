using System;
using System.Collections.Generic;
using BetaSeries.API.Model;

namespace BetaSeries.API.Exceptions
{
	public class BetaSeriesErrorsException : Exception
	{
		public List<Error> Errors { get; private set; }

		public BetaSeriesErrorsException(List<Error> errors)
		{
			Errors = new List<Error>(errors);
		}
	}
}