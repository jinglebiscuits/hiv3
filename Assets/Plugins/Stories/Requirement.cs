using System.Collections;

public class Requirement {

	private IQuality quality;
	private int qualityMin;
	private int qualityMax;

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
