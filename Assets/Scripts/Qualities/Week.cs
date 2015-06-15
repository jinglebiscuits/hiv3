using System;

[Serializable]
public class Week : IQuality {

	private string name;
	private string description;
	private string tag;
	private int level;
	private int points;
	private bool pyramid;
	
	private int dayNumber;
	private string dayName;
	
	#region Constructors
	public Week()
	{
		this.name = "Week";
		this.level = 0;
		this.points = 0;
		this.pyramid = false;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Week"/> class.
	/// </summary>
	/// <param name="level">Level.</param>
	public Week (int level)
	{
		this.name = "Week";
		this.level = level;
		this.points = 0;
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

	public int Level {
		get {
			return this.level;
		}
		set {
			level = value;
		}
	}

	public int GetModifiedLevel ()
	{
		return Level;
	}

	public int Points {
		get {
			return this.points;
		}
		set {
			points = value;
		}
	}

	public bool Pyramid {
		get {
			return this.pyramid;
		}
		set {
			pyramid = value;
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
}
