using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BranchView : MonoBehaviour {
	
	private Branch branch;
	public Image branchIcon;
	public Text branchTitle;
	public Text branchDescription;
	public Text buttonText;
	public Player player;

	public void Awake()
	{
//		TestMethod();
//		branchTitle.text = branch.Title;
//		branchDescription.text = branch.Description;
//		buttonText.text = branch.ButtonText;
		player = GameObject.FindWithTag("Player").GetComponent<Player>();
		print (player.FocusedPerson.Qualities.Count);
	}

	public Branch Branch {
		get {
			return this.branch;
		}
		set {
			branch = value;
			if(branch.SuccessResult != null)
				branch.CalculateChanceOfSuccess(player.FocusedPerson);
			branchTitle.text = branch.Title;
			branchDescription.text = branch.Description;
			buttonText.text = branch.ButtonText;
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
