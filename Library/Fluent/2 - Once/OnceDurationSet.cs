﻿namespace FluentScheduler
{
	/// <summary>
	/// Duration of "once" run has been set, but not its unit.
	/// </summary>
	public class OnceDurationSet
	{
		private readonly int _duration;

		private readonly TimeCalculator _calculator;

		internal OnceDurationSet(int duration, TimeCalculator calculator)
		{
			_duration = duration;
			_calculator = calculator;
		}

		/// <summary>
		/// Sets the unit as seconds.
		/// </summary>
		public void Seconds() => _calculator.OnceCalculation = last => last.AddSeconds(_duration);

		/// <summary>
		/// Sets the unit as minutes.
		/// </summary>
		public void Minutes() => _calculator.OnceCalculation = last => last.AddMinutes(_duration);

		/// <summary>
		/// Sets the unit as hours.
		/// </summary>
		public void Hours() => _calculator.OnceCalculation = last => last.AddHours(_duration);

		/// <summary>
		/// Sets the unit as days.
		/// </summary>
		public PeriodOnceSet Days()
		{
			_calculator.OnceCalculation = last => last.AddDays(_duration);
			return new PeriodOnceSet(_calculator);
		}

		/// <summary>
		/// Sets the unit as weeks.
		/// </summary>
		public PeriodOnceSet Weeks()
		{
			_calculator.OnceCalculation = last => last.AddDays(7 * _duration);
			return new PeriodOnceSet(_calculator);
		}

		/// <summary>
		/// Sets the unit as months.
		/// </summary>
		public MonthUnit Months()
		{
			_calculator.OnceCalculation = last => last.AddMonths(_duration);

			return new MonthUnit(_calculator);
		}
	}
}
