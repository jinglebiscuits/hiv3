using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultView : MonoBehaviour {

	private Result result;
	public Text resultTitle;
	public Text resultDescription;
	public Text resultEffects;
	public Text buttonText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Result Result {
		get {
			return this.result;
		}
		set {
			result = value;
			resultTitle.text = result.Title;
			resultDescription.text = result.Description;
			resultEffects.text = result.QualityAffected.Name + " gains " + result.ChangedBy + " points!" + "Time cost:" + result.TimeCost + " hour";
		}
	}

	public void BackToStoryView()
	{
		transform.parent.GetComponent<StoryContainer>().ShowStories();
	}
}
