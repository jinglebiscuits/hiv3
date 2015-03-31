using UnityEngine;
using System.Collections;

public class ClockView : MonoBehaviour {

	private Person person;
	private Clock clock;
	public GameObject hourHand;

	// Use this for initialization
	void Start ()
	{
		clock = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.Clock;
		clock.pointEvent += UpdateClock;
		UpdateClock();
	}
	
	private void UpdateClock()
	{
		hourHand.transform.rotation = Quaternion.Euler(0, 0, -30 * clock.Level);
	}
}
