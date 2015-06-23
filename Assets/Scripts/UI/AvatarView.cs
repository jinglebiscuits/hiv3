using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AvatarView : MonoBehaviour {

	public Image hair;
	public Image body;
	public Image headColor;
	public Image headLines;
	public Image pants;
	public Image shirt;
	public Image shoes;
	public Image sclera;
	public Image iris;
	public Image lips;

	public Image profileHair;
	public Image profileBody;
	public Image profileHeadColor;
	public Image profileHeadLines;
	public Image profileShirt;
	public Image profileSclera;
	public Image profileIris;
	public Image profileLips;
	public Image profileBorder;
	public Image profileBackground;

	private Avatar playerAvatar;
	public ProfileAvatarView profileAvatarView;

	public GameObject fullFemaleView;
	public GameObject fullMaleView;

	public Sprite profilePicSprite = new Sprite();
	private Texture2D newBodyTexture;
	private Vector2 bottomLeft = new Vector2(0, 1226);

	public Sprite[] femaleHeadColors;
	public Sprite[] femaleHeadLineses;
	public Sprite[] femaleHairs;
	public Sprite[] femaleShirts;
	public Sprite[] femalePants;
	public Sprite[] femaleShoes;
	
	public Sprite[] maleHeadColors;
	public Sprite[] maleHeadLineses;
	public Sprite[] maleHairs;
	public Sprite[] maleShirts;
	public Sprite[] malePants;
	public Sprite[] maleShoes;

	private Dictionary<int, Sprite> avatarDictionary = new Dictionary<int, Sprite>();
	private int head = 0;
	

	// Use this for initialization
	void Start () {
		avatarDictionary.Add(Constants.FEMALE_HEAD_ONE, femaleHeadColors[0]);
		avatarDictionary.Add(Constants.FEMALE_HEAD_TWO, femaleHeadColors[1]);
		avatarDictionary.Add(Constants.FEMALE_HEAD_THREE, femaleHeadColors[2]);
		avatarDictionary.Add(Constants.FEMALE_HAIR_ONE, femaleHairs[0]);
		avatarDictionary.Add(Constants.FEMALE_HAIR_TWO, femaleHairs[1]);
		avatarDictionary.Add(Constants.FEMALE_HAIR_THREE, femaleHairs[2]);
		avatarDictionary.Add(Constants.FEMALE_HAIR_FOUR, femaleHairs[3]);
		avatarDictionary.Add(Constants.FEMALE_SHIRT_ONE, femaleShirts[0]);
		avatarDictionary.Add(Constants.FEMALE_SHIRT_TWO, femaleShirts[1]);
		avatarDictionary.Add(Constants.FEMALE_SHIRT_THREE, femaleShirts[2]);
		avatarDictionary.Add(Constants.FEMALE_PANTS_ONE, femalePants[0]);
		avatarDictionary.Add(Constants.FEMALE_PANTS_TWO, femalePants[1]);
		avatarDictionary.Add(Constants.FEMALE_PANTS_THREE, femalePants[2]);
		avatarDictionary.Add(Constants.FEMALE_PANTS_FOUR, femalePants[3]);
		avatarDictionary.Add(Constants.FEMALE_SHOES_ONE, femaleShoes[0]);
		avatarDictionary.Add(Constants.FEMALE_SHOES_TWO, femaleShoes[1]);
		avatarDictionary.Add(Constants.FEMALE_SHOES_THREE, femaleShoes[2]);
		
		avatarDictionary.Add(Constants.MALE_HEAD_ONE, maleHeadColors[0]);
		avatarDictionary.Add(Constants.MALE_HEAD_TWO, maleHeadColors[1]);
		avatarDictionary.Add(Constants.MALE_HEAD_THREE, maleHeadColors[2]);
		avatarDictionary.Add(Constants.MALE_HAIR_ONE, maleHairs[0]);
		avatarDictionary.Add(Constants.MALE_HAIR_TWO, maleHairs[1]);
		avatarDictionary.Add(Constants.MALE_HAIR_THREE, maleHairs[2]);
		avatarDictionary.Add(Constants.MALE_HAIR_FOUR, maleHairs[3]);
		avatarDictionary.Add(Constants.MALE_SHIRT_ONE, maleShirts[0]);
		avatarDictionary.Add(Constants.MALE_SHIRT_TWO, maleShirts[1]);
		avatarDictionary.Add(Constants.MALE_SHIRT_THREE, maleShirts[2]);
		avatarDictionary.Add(Constants.MALE_PANTS_ONE, malePants[0]);
		avatarDictionary.Add(Constants.MALE_PANTS_TWO, malePants[1]);
		avatarDictionary.Add(Constants.MALE_PANTS_THREE, malePants[2]);
		avatarDictionary.Add(Constants.MALE_SHOES_ONE, maleShoes[0]);
		avatarDictionary.Add(Constants.MALE_SHOES_TWO, maleShoes[1]);
		
		playerAvatar = Player.player.avatar;
		profileHair = playerAvatar.profileHair;
		profileBody = playerAvatar.profileBody;
		profileHeadColor = playerAvatar.profileHeadColor;
		profileHeadLines = playerAvatar.profileHeadLines;
		profileShirt = playerAvatar.profileShirt;
		profileSclera = playerAvatar.profileSclera;
		profileIris = playerAvatar.profileIris;
		profileLips = playerAvatar.profileLips;
		profileBorder = playerAvatar.profileBorder;
		profileBackground = playerAvatar.profileBackground;
//		profilePicSprite = Sprite.Create(CalculateTexture(1869, 589, 30, 294, 1500, body.sprite.texture), new Rect(0, 0, 100, 100), new Vector2(50, 50));
	}

	void OnLevelWasLoaded(int level)
	{
		playerAvatar = Player.player.avatar;
		if(level == 1)
		{
			if(Player.player.FocusedPerson.BodyType == BodyType.female)
			{
				headColor.sprite = playerAvatar.headColor.sprite;
				headColor.color = playerAvatar.headColor.color;
				lips.sprite = playerAvatar.lips.sprite;
				lips.color = playerAvatar.lips.color;
			}
			
			hair.sprite = playerAvatar.hair.sprite;
			hair.color = playerAvatar.hair.color;
			body.sprite = playerAvatar.body.sprite;
			body.color = playerAvatar.body.color;
			
			headLines.sprite = playerAvatar.headLines.sprite;
			headLines.color = playerAvatar.headLines.color;
			pants.sprite = playerAvatar.pants.sprite;
			pants.color = playerAvatar.pants.color;
			shirt.sprite = playerAvatar.shirt.sprite;
			shirt.color = playerAvatar.shirt.color;
			shoes.sprite = playerAvatar.shoes.sprite;
			shoes.color = playerAvatar.shoes.color;
			sclera.sprite = playerAvatar.sclera.sprite;
			sclera.color = playerAvatar.sclera.color;
			iris.sprite = playerAvatar.iris.sprite;
			iris.color = playerAvatar.iris.color;
		}
	}

	// Update is called once per frame
	void LateUpdate () {

	}

	public void CycleHeads()
	{
		head ++;
		if(head >= femaleHeadColors.Length)
			head = 0;
		headColor.sprite = femaleHeadColors[head];
		headLines.sprite = femaleHeadLineses[head];
	}

	public void CreateProfileIcon()
	{
		Avatar avatar = Player.player.avatar;
		if(headColor)
		{
			profileLips.gameObject.SetActive(true);
			profileHeadColor.gameObject.SetActive(true);
			AvatarToProfile(hair, profileHair);
			AvatarToProfile(shirt, profileShirt);
			AvatarToProfile(body, profileBody);
			AvatarToProfile(headColor, profileHeadColor);
			AvatarToProfile(headLines, profileHeadLines);
			AvatarToProfile(iris, profileIris);
			AvatarToProfile(sclera, profileSclera);
			AvatarToProfile(lips, profileLips);
		}
		else
		{
			profileLips.gameObject.SetActive(false);
			profileHeadColor.gameObject.SetActive(false);
			AvatarToProfile(hair, profileHair);
			AvatarToProfile(shirt, profileShirt);
			AvatarToProfile(body, profileBody);
			AvatarToProfile(headLines, profileHeadLines);
			AvatarToProfile(iris, profileIris);
			AvatarToProfile(sclera, profileSclera);
		}
		profileAvatarView.SyncAvatarProfile();
		SyncAvatar();
//		newBodyTexture = MakeBorder();
//		profilePicSprite = Sprite.Create(newBodyTexture, new Rect(0, 0, newBodyTexture.width, newBodyTexture.height), new Vector2(0.5f, 0.5f));
//		profilePicSprite.name = "profilePick";
//		profileBorder.sprite = profilePicSprite;
//		profileBorder.color = Color.white;
//
//		newBodyTexture = MakeBackground();
//		profilePicSprite = Sprite.Create(newBodyTexture, new Rect(0, 0, newBodyTexture.width, newBodyTexture.height), new Vector2(0.5f, 0.5f));
//		profilePicSprite.name = "profilePick";
//		profileBackground.sprite = profilePicSprite;
//		profileBackground.color = Color.white;
	}

	public void SyncAvatar()
	{
		playerAvatar = Player.player.avatar;
		
		if(Player.player.FocusedPerson.BodyType == BodyType.female)
		{
			playerAvatar.headColor.GetComponent<Image>().sprite = headColor.sprite;
			playerAvatar.headColor.GetComponent<Image>().color = headColor.color;
			playerAvatar.lips.GetComponent<Image>().sprite = lips.sprite;
			playerAvatar.lips.GetComponent<Image>().color = lips.color;
		}

		playerAvatar.hair.GetComponent<Image>().sprite = hair.sprite;
		playerAvatar.hair.GetComponent<Image>().color = hair.color;
		playerAvatar.body.GetComponent<Image>().sprite = body.sprite;
		playerAvatar.body.GetComponent<Image>().color = body.color;
		
		playerAvatar.headLines.GetComponent<Image>().sprite = headLines.sprite;
		playerAvatar.headLines.GetComponent<Image>().color = headLines.color;
		playerAvatar.shirt.GetComponent<Image>().sprite = shirt.sprite;
		playerAvatar.shirt.GetComponent<Image>().color = shirt.color;
		playerAvatar.sclera.GetComponent<Image>().sprite = sclera.sprite;
		playerAvatar.sclera.GetComponent<Image>().color = sclera.color;
		playerAvatar.iris.GetComponent<Image>().sprite = iris.sprite;
		playerAvatar.iris.GetComponent<Image>().color = iris.color;
		playerAvatar.pants.GetComponent<Image>().sprite = pants.sprite;
		playerAvatar.pants.GetComponent<Image>().color = pants.color;
		playerAvatar.shoes.GetComponent<Image>().sprite = shoes.sprite;
		playerAvatar.shoes.GetComponent<Image>().color = shoes.color;
	}

	void AvatarToProfile(Image avatarImage, Image profileImage)
	{
		newBodyTexture = CalculateTexture(avatarImage.sprite.texture);
		profilePicSprite = Sprite.Create(newBodyTexture, new Rect(0, 0, newBodyTexture.width, newBodyTexture.height), new Vector2(0.5f, 0.5f));
		profilePicSprite.name = "profilePick";
		profileImage.sprite = profilePicSprite;
		profileImage.color = avatarImage.color;
	}

	Texture2D CalculateTexture(Texture2D sourceTex){
		int w = 589;
		int h = 589;
		int cx = 294;
		int cy = 294;
		int r = 294;
		Color [] c= sourceTex.GetPixels((int) bottomLeft.x, (int) bottomLeft.y, 589, 589);
		Texture2D b=new Texture2D(h,w, TextureFormat.RGBA32, false);
		for (int i = 0 ; i<c.Length;i++){
			int y=Mathf.FloorToInt(((float)i)/((float)w));
			int x=Mathf.FloorToInt(((float)i-((float)(y*w))));
			if (Mathf.Pow(r, 2)>=(x-cx)*(x-cx)+(y-cy)*(y-cy)){
				b.SetPixel(x, y, c[i]);
			}
			else
			{
				b.SetPixel(x, y, Color.clear);
			}
		}
		b.Apply ();
		return b;
	}

	Texture2D MakeBorder(){
		int w = 589;
		int h = 589;
		int cx = 294;
		int cy = 294;
		int r = 294;
		Texture2D b=new Texture2D(h,w, TextureFormat.RGBA32, false);
		for (int i = 0; i < w * h; i++){
			int y=Mathf.FloorToInt(((float)i)/((float)w));
			int x=Mathf.FloorToInt(((float)i-((float)(y*w))));
			if (Mathf.Pow(r - 20, 2)>(x-cx)*(x-cx)+(y-cy)*(y-cy)){
				b.SetPixel(x, y, Color.clear);
			}
			else if(r*r>=(x-cx)*(x-cx)+(y-cy)*(y-cy)){
				b.SetPixel(x, y, Color.white);
			}
			else
			{
				b.SetPixel(x, y, Color.clear);
			}
		}
		b.Apply ();
		return b;
	}

	Texture2D MakeBackground(){
		int w = 589;
		int h = 589;
		int cx = 294;
		int cy = 294;
		int r = 294;
		Texture2D b=new Texture2D(h,w, TextureFormat.RGBA32, false);
		for (int i = 0; i < w * h; i++){
			int y=Mathf.FloorToInt(((float)i)/((float)w));
			int x=Mathf.FloorToInt(((float)i-((float)(y*w))));
			if (Mathf.Pow(r, 2)>(x-cx)*(x-cx)+(y-cy)*(y-cy)){
				b.SetPixel(x, y, Color.grey);
			}
			else
			{
				b.SetPixel(x, y, Color.clear);
			}
		}
		b.Apply ();
		return b;
	}

	public void DisplayAppropriateBody(BodyType bodyType)
	{
		GameObject appropriateBody;
		if(bodyType == BodyType.female)
		{
			fullMaleView.SetActive(false);
			fullFemaleView.SetActive(true);
			appropriateBody = fullFemaleView;
			headColor = appropriateBody.GetComponent<Avatar>().headColor;
			lips = appropriateBody.GetComponent<Avatar>().lips;
			bottomLeft = new Vector2(0, 1226);
		}
		else
		{
			fullMaleView.SetActive(true);
			fullFemaleView.SetActive(false);
			appropriateBody = fullMaleView;
			headColor = null;
			lips = null;
			bottomLeft = new Vector2(0, 1280);
		}
			

		hair = appropriateBody.GetComponent<Avatar>().hair;
		body = appropriateBody.GetComponent<Avatar>().body;
		headLines = appropriateBody.GetComponent<Avatar>().headLines;
		pants = appropriateBody.GetComponent<Avatar>().pants;
		shirt = appropriateBody.GetComponent<Avatar>().shirt;
		shoes = appropriateBody.GetComponent<Avatar>().shoes;
		sclera = appropriateBody.GetComponent<Avatar>().sclera;
		iris = appropriateBody.GetComponent<Avatar>().iris;
	}
}
