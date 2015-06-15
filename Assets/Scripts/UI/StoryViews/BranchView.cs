using UnityEngine;
using UnityEngine.UI;

public class BranchView : MonoBehaviour {
	
	private Branch branch;
	public Image branchIcon;
	public Text branchTitle;
	public Text branchDescription;
	public Text chanceOfSuccess;
	public Text buttonText;
	public Sprite[] branchIcons;

	public Branch Branch {
		get {
			return this.branch;
		}
		set {
			branch = value;
			if(branch.SuccessResult != null)
			{
				branch.CalculateChanceOfSuccess(Player.player.FocusedPerson);
				chanceOfSuccess.text = branch.ChanceOfSuccess.ToString() + "% chance of success";
			}
			else
			{
				Destroy(chanceOfSuccess);
			}
			branchTitle.text = branch.Title;
			branchDescription.text = branch.Description;
			buttonText.text = branch.ButtonText;
			AssignIcon();
		}
	}

	private void AssignIcon()
	{
		string icon = branch.Icon;
		switch (icon) {
		case "drinking_drugs":
			branchIcon.sprite = branchIcons[0];
			break;
		case "jogging":
			branchIcon.sprite = branchIcons[1];
			break;
		case "helping":
			branchIcon.sprite = branchIcons[2];
			break;
		case "party":
			branchIcon.sprite = branchIcons[3];
			break;
		case "basketball":
			branchIcon.sprite = branchIcons[4];
			break;
		case "videoGames":
			branchIcon.sprite = branchIcons[5];
			break;
		case "sex":
			branchIcon.sprite = branchIcons[6];
			break;
		case "socialMedia":
			branchIcon.sprite = branchIcons[7];
			break;
		case "studying":
			branchIcon.sprite = branchIcons[8];
			break;
		case "flirting":
			branchIcon.sprite = branchIcons[9];
			break;
		case "nurse":
			branchIcon.sprite = branchIcons[10];
			break;
		case "empty":
			branchIcon.sprite = branchIcons[11];
			break;
		case "auntie_gina_uncle_harry":
			branchIcon.sprite = branchIcons[12];
			break;
		case "coach_woodfin":
			branchIcon.sprite = branchIcons[13];
			break;
		case "jay_jay":
			branchIcon.sprite = branchIcons[14];
			break;
		case "jimmy":
			branchIcon.sprite = branchIcons[15];
			break;
		case "monique":
			branchIcon.sprite = branchIcons[16];
			break;
		case "mrs_lake":
			branchIcon.sprite = branchIcons[17];
			break;
		case "nurse_roberts":
			branchIcon.sprite = branchIcons[18];
			break;
		case "tia":
			branchIcon.sprite = branchIcons[19];
			break;
		}
	}

	public void ChooseBranch()
	{
		branch.ChooseBranch(Player.player.FocusedPerson);
		if(branch.TravelToArea != null)
			Player.player.FocusedPerson.Area = branch.TravelToArea;
		transform.parent.GetComponent<StoryContainer>().ShowResult(branch.ChosenResult);
	}
}
