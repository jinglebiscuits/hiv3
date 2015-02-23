using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EffectView : MonoBehaviour {
	
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
			resultEffects.text = result.Effects[0].QualityEffected.Name + " gains " + result.Effects[0].ChangedBy + " points!\n" + "Time cost:" + result.TimeCost + " hour";
			buttonText.text = "Return";
		}
	}
	
	public void BackToStoryView()
	{
		transform.parent.GetComponent<StoryContainer>().ShowStories();
	}
}
