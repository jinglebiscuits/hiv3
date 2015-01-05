public interface IQuality {

	string Name
	{
		get;
		set;
	}

	string Description
	{
		get;
		set;
	}

	string Tag
	{
		get;
		set;
	}

	int Level
	{
		get;
		set;
	}

	int Points
	{
		get;
		set;
	}

	bool Pyramid
	{
		get;
		set;
	}

	void AddPoints(int points);
}
