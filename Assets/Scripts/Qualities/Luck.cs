using System.Collections;
using System;

[Serializable]
public class Luck : IQuality {
   
    private string name;
    private string description;
    private string tag;
    private int level;
    private int points;
    private int modifier;
    private bool pyramid;

    public Luck(string name) {
        this.name = "Luck";
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public Luck(string description, int level, int points, bool pyramid)
    {
        this.name = "Luck";
        Description = description;
        Level = level;
        Points = points;
        Pyramid = pyramid;
        this.tag = "Luck";
    }
    
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
    
    public int Level
    {
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
        return (Level + Modifier);
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
    
    //  public void AddPoints(int _points)
    //  {
    //      while (_points > 0)
    //      {
    //          Points += 1;
    //          if(Pyramid)
    //          {
    //              //check to see if ability should level up
    //              if(Points >= Level)
    //              {
    //                  LevelUp();
    //              }
    //          }
    //          else
    //          {
    //              LevelUp();
    //          }
    //
    //          _points --;
    //      }
    //  }
    
    /// <summary>
    /// To replace above method.
    /// </summary>
    /// <param name="_points">_points.</param>
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
        level += 1;
        Points = 0;
    }
    
    private void LevelDown()
    {
        level -= 1;
        if(Pyramid)
        {
            Points = level - 1;
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
