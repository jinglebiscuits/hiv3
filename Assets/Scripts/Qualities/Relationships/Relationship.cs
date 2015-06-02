using System.Collections;

public class Relationship : IQuality {
	
	private string name;
	private string description;
	private string tag;
	private int level;
	private int points;
    private int friendPoints;
	private int modifier;
	private bool pyramid;
	
    public delegate void MyEventHandler(string name);
    public event MyEventHandler pointEvent;
	
	public Relationship (string name)
	{
		this.name = name;
		this.tag = "Relationship";
	}
	
	public Relationship (string name, string description, int level, int points, int modifier, bool pyramid)
	{
		this.name = name;
		this.description = description;
		this.level = level;
		this.points = points;
		this.modifier = modifier;
		this.pyramid = pyramid;
		this.tag = "Relationship";
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

	public int Modifier {
		get {
			return this.modifier;
		}
		set {
			modifier = value;
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

    public int FriendPoints {
        get {
            return GetFriendPoints();
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
	
    public int GetFriendPoints() {
        int friendPoints = 0;

        for (int i = 1; i <= level; i++) {
            friendPoints += i;
        }

        friendPoints += points;

        return friendPoints;
    }

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

        //let subscribers know
        if(pointEvent != null)
        {
            pointEvent(this.name);
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

        //let subscribers know
        if(pointEvent != null)
        {
            pointEvent(this.name);
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
	
//    public int CompareTo (IQuality other)
//    {
//        return (this as Relationship).FriendPoints.CompareTo((other as Relationship).FriendPoints);
//    }

	public int CompareTo (Relationship other)
	{
		return this.FriendPoints.CompareTo(other.FriendPoints);
	}
}
