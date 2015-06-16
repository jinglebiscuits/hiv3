﻿using System;

[Serializable]
public class Homework : IQuality {

	private string name;
	private string description;
	private string tag;
	private int level;
	private int points;
	private bool pyramid;
	
    public delegate void MyEventHandler(int level);
    [field:NonSerialized]
    public event MyEventHandler levelEvent;

	public Homework ()
	{
		this.name = "Homework";
		this.tag = "Homework";
		this.pyramid = false;
	}
	
	public Homework (string name, string description, int level, int points, bool pyramid)
	{
		this.name = name;
		this.description = description;
		this.level = level;
		this.points = points;
		this.pyramid = pyramid;
		this.tag = "Homework";
	}
	
	#region accessors
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
            if(levelEvent != null)
            {
                levelEvent(level);
            }
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
	}
	
	public void RemovePoints(int _points)
	{
		while (_points > 0)
		{
            //Homework can't be negative
            if(Level == 0) {
                Points = 0;
                break;
            }

			Points -= 1;
			if(Pyramid)
			{
				//check to see if ability should level down
				if(Points < 0)
				{
					LevelDown();
				}
			}
			else
			{
				LevelDown();
			}
			
			_points --;
		}
	}
	
	/// <summary>
	/// Increases level by 1 and resets points to 0.
	/// </summary>
	private void LevelUp()
	{
		Level += 1;
		Points = 0;
	}
	
	private void LevelDown()
	{
		Level -= 1;
		if(Pyramid)
		{
			Points = Level - 1;
		}
		else
		{
			Points = 0;
		}
	}
	
	public int CompareTo (IQuality other)
	{
		return this.Level.CompareTo(other.Level);
	}
}