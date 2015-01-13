using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HourHand : MonoBehaviour {

	private float hour = 0.0f;

	public float Hour {
		get {
			return this.hour;
		}
		set {
			hour = value;
			transform.rotation = Quaternion.Euler(0, 0, -30 * hour);
		}
	}
}
