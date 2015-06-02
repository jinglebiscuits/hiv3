using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeworkIndicator : MonoBehaviour {

    public Text indicatorText;
    public Color noHomeworkColor;
    public Color maxHomeworkColor;
    public int maxHomework = 10;
    private Homework homework;


	// Use this for initialization
	void Start () {
        Person person = GameObject.Find("Player").GetComponent<Player>().FocusedPerson;
        homework = (Homework) person.QualitiesDict["Homework"];
        homework.levelEvent -= UpdateIndicator;
        homework.levelEvent += UpdateIndicator;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy() {
        homework.levelEvent -= UpdateIndicator;
    }

    public void UpdateIndicator(int level) {
        if (level == 0) {
            indicatorText.text = "None";
        }
        else if (level < 3) {
            indicatorText.text = "Little";
        }
        else if (level < 6) {
            indicatorText.text = "Lots";
        }
        else {
            indicatorText.text = "HELP!";
        }

        indicatorText.color = Color.Lerp(noHomeworkColor, maxHomeworkColor, (float) ((float) level/(float) maxHomework));
    }
}
