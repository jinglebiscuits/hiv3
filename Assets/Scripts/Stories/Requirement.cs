public class Requirement {

	private IQuality quality;
	private int qualityMin;
	private int qualityMax;
	
    /// <param name="quality">The quality to be compared</param>
    /// <param name="qualityMin">minimum quality level</param>
    /// <param name="qualityMax">maximum quality level</param>
	public Requirement(IQuality quality, int qualityMin, int qualityMax)
	{
		this.quality = quality;
		this.qualityMin = qualityMin;
		this.qualityMax = qualityMax;
	}

	public IQuality Quality {
		get {
			return this.quality;
		}
	}

	public int QualityMin {
		get {
			return this.qualityMin;
		}
	}

	public int QualityMax {
		get {
			return this.qualityMax;
		}
	}
}