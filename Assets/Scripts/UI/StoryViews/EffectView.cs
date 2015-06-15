using UnityEngine;
using UnityEngine.UI;

public class EffectView : MonoBehaviour {
	
	private Result result;
	public Text resultTitle;
	public Text resultDescription;
	public Text resultEffects;
	public Text buttonText;
	
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
