using System.Collections;

public class Clock {
	
	private int hour;

	public delegate void MyEventHandler();
	public event MyEventHandler clockEvent;

	public Clock()
	{
		hour = 0;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Clock"/> class with the current hour.
	/// </summary>
	/// <param name="hour">Hour.</param>
	public Clock(int hour)
	{
		this.hour = hour;
	}

	public int Hour
	{
		get
		{
			return hour;
		}
		set
		{
			//let subscribers know
			if(clockEvent != null)
			{
				clockEvent();
			}

			if(value >= 24)
			{
				value = value - 24;
				NewDay();
			}
			hour = value;
		}
	}

	private void NewDay()
	{
		//start a new day
	}
}
