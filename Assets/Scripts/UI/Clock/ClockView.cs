using UnityEngine;
using UnityEngine.UI;

public class ClockView : MonoBehaviour {

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
		Person person = Player.player.FocusedPerson;
		clock = person.Clock;
		day = person.Day;
		week = person.Week;
		clock.pointEvent += UpdateClock;
		clock.newDayEvent += NewDay;
		day.newWeekEvent += NewWeek;
		UpdateClock();
	}

	void OnDestroy()
	{
		clock.pointEvent -= UpdateClock;
		clock.newDayEvent -= NewDay;
		day.newWeekEvent -= NewWeek;
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
		day.AddPoints(1);
	}

	private void NewWeek()
	{
		week.AddPoints(1);
		if(week.Level == 10)
		{
			Application.LoadLevel("EndScene");
		}
	}

	public void Sleep(int hours=8)
	{
		int hoursSlept = 0;
		while(clock.Level >= 20 | clock.Level <= 6)
		{
			clock.AddPoints(1);
			hoursSlept ++;
		}
		if(hoursSlept >= 7)
		{
			print ("7 hours");
			Player.player.FocusedPerson.QualitiesDict["Well Rested"].Level = 1;
		}
		else
			Player.player.FocusedPerson.QualitiesDict["Well Rested"].Level --;
		GameObject.Find("StoryContainer").GetComponent<StoryContainer>().ShowStories();
	}
}
