﻿using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour {

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
			resultEffects.text = "";
			foreach(Effect effect in result.Effects)
			{
				if (effect.Show) {
					if(effect.ChangedBy != 169)
						resultEffects.text += effect.QualityEffected.Name + " gains " + effect.ChangedBy + " points!\n";
					else
					{
						resultEffects.text += effect.QualityEffected.Name + " set to level " + effect.SetTo + "\n";
					}
				}	
			}
//			resultEffects.text = result.Effects[0].QualityEffected.Name + " gains " + result.Effects[0].ChangedBy + " points!\n" + "Time cost:" + result.TimeCost + " hour";
			//resultEffects.text = effectsString;
			buttonText.text = "Return";
		}
	}

	public void BackToStoryView()
	{
		transform.parent.GetComponent<StoryContainer>().ShowStories();
	}
}
