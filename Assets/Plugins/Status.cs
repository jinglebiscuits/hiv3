using UnityEngine;
using System.Collections;

public class Status : IQuality {

	private string name;
	private string description;
	private string tag;
	private int level;
	private int points;
	private int modifier;
	private bool pyramid;

	public Status (string name, string description, int level, int points, int modifier, bool pyramid)
	{
		this.name = name;
		this.description = description;
		this.level = level;
		this.points = points;
		this.modifier = modifier;
		this.pyramid = pyramid;
	}
	

	public void AddPoints (int points)
	{
		throw new System.NotImplementedException ();
	}

	public void RemovePoints (int points)
	{
		throw new System.NotImplementedException ();
	}

	#region accessors
	public string Name {
		get {
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
		}
	}

	public string Description {
		get {
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
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
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
		}
	}

	public int Points {
		get {
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
		}
	}

	public bool Pyramid {
		get {
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
		}
	}
	#endregion
}
