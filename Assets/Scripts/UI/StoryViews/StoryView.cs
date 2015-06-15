using UnityEngine;
using UnityEngine.UI;

public class StoryView : MonoBehaviour {

	private Story story;
	public Image storyIcon;
	public Text storyName;
	public Text storyDescription;
	public Text buttonText;
	public Sprite[] storyIcons;

	public Story Story {
		get {
			return this.story;
		}
		set {
			story = value;
			storyName.text = story.Title;
			storyDescription.text = story.Description;
			buttonText.text = story.ButtonText;
			AssignIcon();
		}
	}

	private void AssignIcon()
	{
		string icon = story.Icon;
		switch (icon) {
		case "drinking_drugs":
			storyIcon.sprite = storyIcons[0];
			break;
		case "jogging":
			storyIcon.sprite = storyIcons[1];
			break;
		case "helping":
			storyIcon.sprite = storyIcons[2];
			break;
		case "party":
			storyIcon.sprite = storyIcons[3];
			break;
		case "basketball":
			storyIcon.sprite = storyIcons[4];
			break;
		case "videoGames":
			storyIcon.sprite = storyIcons[5];
			break;
		case "sex":
			storyIcon.sprite = storyIcons[6];
			break;
		case "socialMedia":
			storyIcon.sprite = storyIcons[7];
			break;
		case "studying":
			storyIcon.sprite = storyIcons[8];
			break;
		case "flirting":
			storyIcon.sprite = storyIcons[9];
			break;
		case "nurse":
			storyIcon.sprite = storyIcons[10];
			break;
		case "empty":
			storyIcon.sprite = storyIcons[11];
			break;
		}
	}

	public void ChooseTrunk()
	{
		//switch to trunk view
		transform.parent.GetComponent<StoryContainer>().ShowBranches((Trunk) story);
	}
}
