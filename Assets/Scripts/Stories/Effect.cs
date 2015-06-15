public class Effect {

	private IQuality qualityEffected;
	private int changedBy;
	private int setTo;

	#region Constructors
	public Effect (IQuality qualityEffected, int changedBy = 169, int setTo = 169)
	{
		this.qualityEffected = qualityEffected;
		this.changedBy = changedBy;
		this.setTo = setTo;
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
			changedBy = (int) value;
		}
	}

	public int SetTo {
		get {
			return this.setTo;
		}
		set {
			setTo = value;
		}
	}
	#endregion
}
