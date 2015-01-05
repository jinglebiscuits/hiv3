﻿using System.Collections;

public class Attribute : IQuality {

	public delegate void MyEventHandler();
	public event MyEventHandler pointEvent;
	public event MyEventHandler levelEvent;

	private string name;
	private string description;
	private string tag;
	private int level;
	private int points;
	private int modifier;
	private bool pyramid;

	/// <summary>
	/// Default constructor
	/// </summary>
	public Attribute() : this("null", "null", 0, 0, false)
	{
		
	}
	
	
	/// <summary>
	/// Constructor
	/// </summary>
	public Attribute(string name, string description, int level, int points, bool pyramid)
	{
		Name = name;
		Description = description;
		Level = level;
		Points = points;
		Pyramid = pyramid;
	}

	#region Properties
	
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

	public int Level
	{
		get;
		set;
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

	#endregion

	public void AddPoints(int _points)
	{
		while (_points > 0)
		{
			Points += 1;
			if(Pyramid)
			{
				//check to see if ability should level up
				if(Points >= Level)
				{
					LevelUp();
				}
			}
			else
			{
				LevelUp();
			}

			_points --;
		}
		Points += _points;
		if(pyramid)
		{
			if(Points >= Level)
			{

				Points -= Level;
				Level += 1;
			}
		}
	}


	/// <summary>
	/// Increases level by 1 and resets points to 0.
	/// </summary>
	public void LevelUp()
	{
		Level += 1;
		Points = 0;
	}
	

}
