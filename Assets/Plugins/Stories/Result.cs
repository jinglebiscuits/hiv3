using System.Collections;

public class Result {

	private string title;
	private string description;
	private IQuality qualityAffected;
	private int changedBy;

	#region Constructors
	public Result ()
	{
		this.title = "Result_Title";
		this.description = "Result_Description";
		this.qualityAffected = new Attribute();
		this.changedBy = 0;
	}

	public Result (string title, string description, IQuality qualityAffected, int changedBy)
	{
		this.title = title;
		this.description = description;
		this.qualityAffected = qualityAffected;
		this.changedBy = changedBy;
	}
	#endregion

	#region Accessor Methods
	public string Title {
		get {
			return this.title;
		}
		set {
			title = value;
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

	public IQuality QualityAffected {
		get {
			return this.qualityAffected;
		}
		set {
			qualityAffected = value;
		}
	}

	public int ChangedBy {
		get {
			return this.changedBy;
		}
		set {
			changedBy = value;
		}
	}
	#endregion

	public void AffectCharacter(Person person)
	{
		//do the things
		person.baseAttributes.intelligence.AddPoints(changedBy);
	}
}
