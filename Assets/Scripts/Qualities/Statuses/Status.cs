using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Status : IQuality {

	public delegate void MyEventHandler(Status status);
    [field:NonSerialized]
	public event MyEventHandler levelEvent;

	private string name;
	private string description;
	private string tag;
	private int level;
	private int oldLevel;
	private int points;
	private Dictionary<string, int> modDictionary = new Dictionary<string, int>();
	private bool pyramid;


	public Status (string name)
	{
		this.name = name;
		this.tag = "Status";
	}

	public Status (string name, string description, int level, int points, int intMod, int physMod, int socMod, int mettleMod, bool pyramid)
	{
		this.name = name;
		this.description = description;
		this.level = level;
		this.oldLevel = level;
		this.points = points;
		this.modDictionary.Add("Intelligence", intMod);
		this.modDictionary.Add("Physical", physMod);
		this.modDictionary.Add("Social", socMod);
		this.modDictionary.Add("Mettle", mettleMod);
		this.pyramid = pyramid;
		this.tag = "Status";
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

	/// <summary>
	/// Gets or sets the level. Only set to -1, 0, or 1
	/// </summary>
	/// <value>The level.</value>
	public int Level {
		get {
			return this.level;
		}
		set {
			Debug.Log (value);
			int newValue = Math.Max(value, -1);
			newValue = Math.Min (newValue, 1);
			Debug.Log (newValue);
			if(newValue != level)
			{
				oldLevel = level;
				level = newValue;
				if(levelEvent != null)
				{
					levelEvent(this);
				}
			}
		}
	}

	public int OldLevel {
		get {
			return this.oldLevel;
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

	public Dictionary<string, int> ModDictionary {
		get {
			return this.modDictionary;
		}
		set {
			modDictionary = value;
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
