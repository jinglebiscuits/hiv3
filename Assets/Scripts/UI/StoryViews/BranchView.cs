using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BranchView : MonoBehaviour {
	
	private Branch branch;
	public Image branchIcon;
	public Text branchTitle;
	public Text branchDescription;
	public Text chanceOfSuccess;
	public Text buttonText;
	public Sprite[] branchIcons;
	public Player player;

	public void Awake()
	{
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}

	public Branch Branch {
		get {
			return this.branch;
		}
		set {
			branch = value;
			if(branch.SuccessResult != null)
			{
				branch.CalculateChanceOfSuccess(player.FocusedPerson);
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
		}
	}

//	public void TestMethod()
//	{
//		branch = new Branch("Get Smart!", "You will gain knowledge", "brain_icon", "Learn", new List<Requirement>(), new Result());
//		branch.DefaultResult.Title = "You out smart them!";
//		branch.DefaultResult.Description = "They were never really a threat anyway.";
//		branch.DefaultResult.QualityAffected = new Attribute("Social"); //This determines which quality is affected. This is temporary.
//		branch.DefaultResult.ChangedBy = 2;
//	}

	public void ChooseBranch()
	{
		branch.ChooseBranch(player.FocusedPerson);
		transform.parent.GetComponent<StoryContainer>().ShowResult(branch.ChosenResult);
	}
}
