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
		clock.clockEvent += UpdateClock;
	}
	
	private void UpdateClock()
	{
		hourHand.GetComponent<HourHand>().Hour = clock.Hour;
	}
}
