using UnityEngine;
using System.Collections;

public class Day : IQuality {

	private string name;
	private string description;
	private string tag;
	private int level;
	private int points;
	private bool pyramid;
	
	private string dayName;

	public delegate void MyEventHandler();
	public event MyEventHandler pointEvent;
	public event MyEventHandler newWeekEvent;

	#region Constructors
	public Day()
	{
		this.level = 0;
		this.points = 0;
		this.pyramid = false;
	}
	/// <summary>
	/// Initializes a new instance of the <see cref="Day"/> class.
	/// </summary>
	/// <param name="level">Level.</param>
	public Day (int level)
	{
		this.level = level;
		this.points = 0;
		this.pyramid = false;
	}
	#endregion

	#region Accessor Methods
	public string DayName {
		get {
			switch (level)
			{
			case 0:
				return "Mon";
				break;
			case 1:
				return "Tue";
				break;
			case 2:
				return "Wed";
				break;
			case 3:
				return "Thu";
				break;
			case 4:
				return "Fri";
				break;
			case 5:
				return "Sat";
				break;
			case 6:
				return "Sun";
				break;
			default:
				return "not a day";
				break;
			}
		}
		set {
			dayName = value;
		}
	}

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
			if(value >= 7) {
				value = value - 7;
				NewWeek();
			}
			level = value;
			
			DayName = DayName;
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

	public void NewWeek()
	{
		//let subscribers know
		if(newWeekEvent != null)
		{
			newWeekEvent();
		}
	}
}
