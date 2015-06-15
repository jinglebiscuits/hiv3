using UnityEngine;
using UnityEngine.UI;

public class ProfileAvatarView : MonoBehaviour {

	public GameObject player;
	private Avatar playerAvatar;

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
		if(player == null)
		{
			player = GameObject.Find("Player");
			playerAvatar = player.GetComponent<Avatar>();
		}
		else
			playerAvatar = player.GetComponent<Avatar>();

		if(Player.player.FocusedPerson.BodyType == BodyType.female)
		{
			profileHeadColor.SetActive(true);
			profileLips.SetActive(true);
			profileHeadColor.GetComponent<Image>().sprite = playerAvatar.profileHeadColor.sprite;
			profileHeadColor.GetComponent<Image>().color = playerAvatar.profileHeadColor.color;
			profileLips.GetComponent<Image>().sprite = playerAvatar.profileLips.sprite;
			profileLips.GetComponent<Image>().color = playerAvatar.profileLips.color;
		}
		else
		{
			profileHeadColor.SetActive(false);
			profileLips.SetActive(false);
		}
		profileHair.GetComponent<Image>().sprite = playerAvatar.profileHair.sprite;
		profileHair.GetComponent<Image>().color = playerAvatar.profileHair.color;
		profileBody.GetComponent<Image>().sprite = playerAvatar.profileBody.sprite;
		profileBody.GetComponent<Image>().color = playerAvatar.profileBody.color;

		profileHeadLines.GetComponent<Image>().sprite = playerAvatar.profileHeadLines.sprite;
		profileHeadLines.GetComponent<Image>().color = playerAvatar.profileHeadLines.color;
		profileShirt.GetComponent<Image>().sprite = playerAvatar.profileShirt.sprite;
		profileShirt.GetComponent<Image>().color = playerAvatar.profileShirt.color;
		profileSclera.GetComponent<Image>().sprite = playerAvatar.profileSclera.sprite;
		profileSclera.GetComponent<Image>().color = playerAvatar.profileSclera.color;
		profileIris.GetComponent<Image>().sprite = playerAvatar.profileIris.sprite;
		profileIris.GetComponent<Image>().color = playerAvatar.profileIris.color;

		profileBorder.GetComponent<Image>().sprite = playerAvatar.profileBorder.sprite;
		profileBorder.GetComponent<Image>().color = playerAvatar.profileBorder.color;
		profileBackground.GetComponent<Image>().sprite = playerAvatar.profileBackground.sprite;
		profileBackground.GetComponent<Image>().color = playerAvatar.profileBackground.color;
	}
}
