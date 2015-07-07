using UnityEngine;
using UnityEngine.UI;

public class ProfileAvatarView : MonoBehaviour {

	public GameObject profileHair;
	public GameObject profileBody;
	public GameObject profileHeadColor;
	public GameObject profileHeadLines;
	public GameObject profileShirt;
	public GameObject profileSclera;
	public GameObject profileIris;
	public GameObject profileLips;
	public GameObject profileBorder;
	public GameObject profileBackground;

	// Use this for initialization
	void Start () {
		SyncAvatarProfile();
	}

	public void SyncAvatarProfile()
	{
		if(Player.player.FocusedPerson.BodyType == BodyType.female)
		{
			profileHeadColor.SetActive(true);
			profileLips.SetActive(true);
			profileLips.GetComponent<Image>().sprite = Player.player.profileLips.sprite;
			profileLips.GetComponent<Image>().color = Player.player.profileLips.color;
		}
		else
		{
			profileLips.SetActive(false);
		}
		profileHair.GetComponent<Image>().sprite = Player.player.profileHair.sprite;
		profileHair.GetComponent<Image>().color = Player.player.profileHair.color;
		profileBody.GetComponent<Image>().sprite = Player.player.profileBody.sprite;
		profileBody.GetComponent<Image>().color = Player.player.profileBody.color;

		profileHeadColor.GetComponent<Image>().sprite = Player.player.profileHeadColor.sprite;
		profileHeadColor.GetComponent<Image>().color = Player.player.profileHeadColor.color;
		profileHeadLines.GetComponent<Image>().sprite = Player.player.profileHeadLines.sprite;
		profileHeadLines.GetComponent<Image>().color = Player.player.profileHeadLines.color;
		profileShirt.GetComponent<Image>().sprite = Player.player.profileShirt.sprite;
		profileShirt.GetComponent<Image>().color = Player.player.profileShirt.color;
		profileSclera.GetComponent<Image>().sprite = Player.player.profileSclera.sprite;
		profileSclera.GetComponent<Image>().color = Player.player.profileSclera.color;
		profileIris.GetComponent<Image>().sprite = Player.player.profileIris.sprite;
		profileIris.GetComponent<Image>().color = Player.player.profileIris.color;

		profileBorder.GetComponent<Image>().sprite = Player.player.profileBorder.sprite;
		profileBorder.GetComponent<Image>().color = Player.player.profileBorder.color;
		profileBackground.GetComponent<Image>().sprite = Player.player.profileBackground.sprite;
		profileBackground.GetComponent<Image>().color = Player.player.profileBackground.color;
	}
}
