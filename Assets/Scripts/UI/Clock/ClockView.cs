using UnityEngine;
using System.Collections;

public class ClockView : MonoBehaviour {

	private Person person;
	private Clock clock;
	private Day day;
	public GameObject hourHand;

	// Use this for initialization
	void Start ()
	{
		clock = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.Clock;
		day = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.Day;
		clock.pointEvent += UpdateClock;
		clock.newDayEvent += NewDay;
		UpdateClock();
	}
	
	private void UpdateClock()
	{
		hourHand.transform.rotation = Quaternion.Euler(0, 0, -30 * clock.Level);
	}

	private void NewDay()
	{
		print ("new day!!!!!!!!!");
		day.AddPoints(1);
		print (day.DayName);
	}

	public void Sleep(int hours=8)
	{
		clock.AddPoints(hours);
	}
}
