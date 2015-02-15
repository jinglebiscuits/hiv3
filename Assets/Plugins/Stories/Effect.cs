using System.Collections;

public class Effect {

	private IQuality qualityEffected;
	private int changedBy;

	#region Constructors
	public Effect (IQuality qualityEffected, int changedBy)
	{
		this.qualityEffected = qualityEffected;
		this.changedBy = changedBy;
	}
	#endregion

	#region Access Modifiers
	public IQuality QualityEffected {
		get {
			return this.qualityEffected;
		}
		set {
			qualityEffected = value;
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
}
