using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockView : MonoBehaviour {

	private Person person;
	private Clock clock;
	private Day day;
	private Week week;
	public GameObject hourHand;
	public Text dayText;
	public Text weekNumber;
	public GameObject sleepButton;

	// Use this for initialization
	void Start ()
	{
		clock = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.Clock;
		day = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.Day;
		week = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.Week;
		clock.pointEvent += UpdateClock;
		clock.newDayEvent += NewDay;
		day.newWeekEvent += NewWeek;
		UpdateClock();
	}
	
	private void UpdateClock()
	{
		hourHand.transform.rotation = Quaternion.Euler(0, 0, -30 * clock.Level);
		dayText.text = day.DayName;
		weekNumber.text = week.Level.ToString();
		if(clock.Level >= 20 | clock.Level <= 6)
			sleepButton.GetComponent<Button>().interactable = true;
		else
			sleepButton.GetComponent<Button>().interactable = false;
	}

	private void NewDay()
	{
		print ("new day");
		day.AddPoints(1);
	}

	private void NewWeek()
	{
		print ("new week");
		week.AddPoints(1);
		if(week.Level == 10)
		{
			Application.LoadLevel("EndScene");
		}
	}

	public void Sleep(int hours=8)
	{
		while(clock.Level >= 20 | clock.Level <= 6)
		{
			clock.AddPoints(1);
		}
	}
}
