using System.Collections;

public class GameClock {

	private float currentTime;

	#region Constructors
	public GameClock()
	{
		currentTime = 0.0f;
	}

	public GameClock(float currentTime)
	{
		this.currentTime = currentTime;
	}
	#endregion

	#region Accessor Methods
	public float CurrentTime {
		get {
			return this.currentTime;
		}
		set {
			currentTime = value;
		}
	}
	#endregion
}
