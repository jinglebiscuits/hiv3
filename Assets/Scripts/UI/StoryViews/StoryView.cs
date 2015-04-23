using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryView : MonoBehaviour {

	private Story story;
	public Image storyIcon;
	public Text storyName;
	public Text storyDescription;
	public Text buttonText;


	void Start()
	{

	}

	public Story Story {
		get {
			return this.story;
		}
		set {
			story = value;
			storyName.text = story.Title;
			storyDescription.text = story.Description;
			buttonText.text = story.ButtonText;
		}
	}

	public void ChooseTrunk()
	{
		//switch to trunk view
		transform.parent.GetComponent<StoryContainer>().ShowBranches((Trunk) story);
	}
}
