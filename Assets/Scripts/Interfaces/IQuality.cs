using System;

public interface IQuality {

	string Name { get; set;	}
	string Description { get; set; }
	string Tag { get; set; }
	int Level { get; set; }
	/// <summary>
	/// Points in quality towards achieving the next level.
	/// </summary>
	/// <value>The points.</value>
	int Points { get; set; }
	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="IQuality"/> uses pyramid leveling
	/// (it takes the level number of points to reach the next level).
	/// </summary>
	/// <value><c>true</c> if pyramid; otherwise, <c>false</c>.</value>
	bool Pyramid { get;	set; }

	int GetModifiedLevel();
	void AddPoints(int points);
	void RemovePoints(int points);
}
