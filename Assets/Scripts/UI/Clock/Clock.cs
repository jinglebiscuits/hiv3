using System.Collections;

public class Clock : IQuality {

	private string name;
	private string description;
	private string tag;
	private int level;
	private int points;
	private bool pyramid;

	public delegate void MyEventHandler();
	public event MyEventHandler pointEvent;
	public event MyEventHandler newDayEvent;

	#region Constructors
	public Clock()
	{
		this.name = "Time";
		level = 0;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Clock"/> class with the current hour.
	/// </summary>
	/// <param name="hour">Hour.</param>
	public Clock(int level)
	{
		this.level = level;
		this.name = "Time";
		this.description = "keeps the time";
		this.points = 0;
	}

	public Clock (string description, string tag, int level, int points)
	{
		this.name = "Time";
		this.description = description;
		this.tag = tag;
		this.level = level;
		this.points = points;
		this.pyramid = false;
	}
	#endregion

	#region Accessor Methods
	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}
	
	public string Description {
		get {
			return this.description;
		}
		set {
			description = value;
		}
	}
	
	public string Tag {
		get {
			return this.tag;
		}
		set {
			tag = value;
		}
	}
	
	/// <summary>
	/// Counts progress towards next level.
	/// </summary>
	/// <value>The points.</value>
	public int Points {
		get {
			return this.points;
		}
		set {
			points = value;
			//let subscribers know
			if(pointEvent != null)
			{
				pointEvent();
			}
		}
	}

	/// <summary>
	/// if pyramid, then it takes the level amount of points to get to the next level
	/// </summary>
	/// <value><c>true</c> if pyramid; otherwise, <c>false</c>.</value>
	public bool Pyramid
	{
		get {
			return this.pyramid;
		}
		set {
			pyramid = value;
		}
	}

	public int Level
	{
		get
		{
			return level;
		}
		set
		{
			if(value >= 24)
			{
				value = value - 24;
				NewDay();
			}
			level = value;
		}
	}
	#endregion

	public void AddPoints(int _points)
	{
		while (_points > 0)
		{
			Points += 1;
			LevelUp();
			_points --;
		}
	}
	
	public void RemovePoints(int _points)
	{
		while (_points > 0)
		{
			Points -= 1;
			LevelDown();			
			_points --;
		}
	}
	
	private void LevelUp()
	{
		Level += 1;
		Points = 0;
	}
	
	private void LevelDown()
	{
		Level -= 1;
		Points = 0;
	}
	
	public int CompareTo (IQuality other)
	{
		return this.Level.CompareTo(other.Level);
	}

	private void NewDay()
	{
		//let subscribers know
		if(newDayEvent != null)
		{
			newDayEvent();
		}
	}
}
