﻿using System;

[Serializable]
public class Item : IQuality {
	
	private string name;
	private string description;
	private string tag;
	private int level;
	private int points;
	private int cost;
	private bool pyramid;
	
	
	public Item (string name)
	{
		this.name = name;
		this.tag = "Item";
		this.pyramid = false;
	}
	
	public Item (string name, string description, int level, int points, int cost, bool pyramid)
	{
		this.name = name;
		this.description = description;
		this.level = level;
		this.points = points;
		this.cost = cost;
		this.pyramid = pyramid;
		this.tag = "Item";
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
	
	public int Cost {
		get {
			return this.cost;
		}
		set {
			cost = value;
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
