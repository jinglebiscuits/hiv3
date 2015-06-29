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
	public Sprite[] femaleLips;
	public Sprite[] femaleBody;
	public Sprite[] femaleSclera;
	public Sprite[] femaleIris;
	
	public Sprite[] maleHeadColors;
	public Sprite[] maleHeadLineses;
	public Sprite[] maleHairs;
	public Sprite[] maleShirts;
	public Sprite[] malePants;
	public Sprite[] maleShoes;
	public Sprite[] maleBody;
	public Sprite[] maleSclera;
	public Sprite[] maleIris;
	
	private Person person;

	private Dictionary<int, Sprite> avatarDictionary = new Dictionary<int, Sprite>();
	private int head = 0;
	

	// Use this for initialization
	void Awake () {
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
		avatarDictionary.Add(Constants.FEMALE_LIPS_ONE, femaleLips[0]);
		avatarDictionary.Add(Constants.FEMALE_BODY_ONE, femaleBody[0]);
		avatarDictionary.Add(Constants.FEMALE_SCLERA_ONE, femaleSclera[0]);
		avatarDictionary.Add(Constants.FEMALE_IRIS_ONE, femaleIris[0]);
		
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
		avatarDictionary.Add(Constants.MALE_BODY_ONE, maleBody[0]);
		avatarDictionary.Add(Constants.MALE_SCLERA_ONE, maleSclera[0]);
		avatarDictionary.Add(Constants.MALE_IRIS_ONE, maleIris[0]);
		
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
	}

	void OnLevelWasLoaded(int level)
	{
		playerAvatar = Player.player.avatar;
		person = Player.player.FocusedPerson;
		if(level == 1)
		{
			if(Player.player.FocusedPerson.BodyType == BodyType.female)
			{
				headColor.sprite = avatarDictionary[person.HeadColor];
				headColor.color = ArrayToColor(person.HeadColorColor);
				headLines.sprite = femaleHeadLineses[(person.HeadLine % 10) - 1];
				lips.sprite = avatarDictionary[person.Lips];
				lips.color = ArrayToColor(person.LipsColor);
			}
			
			hair.sprite = avatarDictionary[person.Hair];
			hair.color = ArrayToColor(person.HairColor);
			body.sprite = avatarDictionary[person.Body];
			body.color = ArrayToColor(person.BodyColor);
			
			pants.sprite = avatarDictionary[person.Pants];
			pants.color = ArrayToColor(person.PantsColor);
			shirt.sprite = avatarDictionary[person.Shirt];
			shirt.color = ArrayToColor(person.ShirtColor);
			shoes.sprite = avatarDictionary[person.Shoes];
			shoes.color = ArrayToColor(person.ShoesColor);
			sclera.sprite = avatarDictionary[person.Sclera];
			iris.sprite = avatarDictionary[person.Iris];
			iris.color = ArrayToColor(person.IrisColor);
		}
	}

	// Update is called once per frame
	void LateUpdate () {

	}

	public void CyclePart(string part)
	{
		person = Player.player.FocusedPerson;
		if (part == "head") {
			int headPos = person.HeadColor % 10;
			int headBase = person.HeadColor - headPos + 1;
			if(person.BodyType == BodyType.female) {
				if(headPos >= femaleHeadColors.Length)
					headPos = 0;
				headColor.sprite = femaleHeadColors[headPos];
				headLines.sprite = femaleHeadLineses[headPos];
			}
			else {
				if(headPos >= maleHeadColors.Length)
					headPos = 0;
				headColor.sprite = maleHeadColors[headPos];
				headLines.sprite = maleHeadLineses[headPos];
			}
			
			person.HeadColor = headBase + headPos;
			person.HeadLine = headBase + headPos;
		}
		else if (part == "shirt") {
			int shirtPos = person.Shirt % 10;
			int shirtBase = person.Shirt - shirtPos + 1;
			if (person.BodyType == BodyType.female) {
				if(shirtPos >= femaleShirts.Length)
					shirtPos = 0;
				shirt.sprite = femaleShirts[shirtPos];
			}
			else {
				if(shirtPos >= maleShirts.Length)
					shirtPos = 0;
				shirt.sprite = maleShirts[shirtPos];
			}
			person.Shirt = shirtBase + shirtPos;
		}
	}

	public void CreateProfileIcon()
	{
		Avatar avatar = Player.player.avatar;
		if(Player.player.FocusedPerson.BodyType == BodyType.female)
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
			AvatarToProfile(hair, profileHair);
			AvatarToProfile(shirt, profileShirt);
			AvatarToProfile(body, profileBody);
			AvatarToProfile(headColor, profileHeadColor);
			AvatarToProfile(headLines, profileHeadLines);
			AvatarToProfile(iris, profileIris);
			AvatarToProfile(sclera, profileSclera);
		}
		profileAvatarView.SyncAvatarProfile();
		SyncAvatar();
	}

	public void SyncAvatar()
	{
		playerAvatar = Player.player.avatar;
		person = Player.player.FocusedPerson;
		if(Player.player.FocusedPerson.BodyType == BodyType.female)
		{
			person.HeadColorColor = new float[3] {headColor.color.r, headColor.color.g, headColor.color.b};
			person.LipsColor = new float[3] {lips.color.r, lips.color.g, lips.color.b};
		}

		person.HairColor = new float[3] {hair.color.r, hair.color.g, hair.color.b};
		person.BodyColor = new float[3] {body.color.r, body.color.g, body.color.b};
		
		person.ShirtColor = new float[3] {shirt.color.r, shirt.color.g, shirt.color.b};
		person.IrisColor = new float[3] {iris.color.r, iris.color.g, iris.color.b};
		person.PantsColor = new float[3] {pants.color.r, pants.color.g, pants.color.b};
		person.ShoesColor = new float[3] {shoes.color.r, shoes.color.g, shoes.color.b};
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
			lips = appropriateBody.GetComponent<Avatar>().lips;
			bottomLeft = new Vector2(0, 1226);
		}
		else
		{
			fullMaleView.SetActive(true);
			fullFemaleView.SetActive(false);
			appropriateBody = fullMaleView;
			lips = null;
			bottomLeft = new Vector2(0, 1280);
		}
			

		hair = appropriateBody.GetComponent<Avatar>().hair;
		body = appropriateBody.GetComponent<Avatar>().body;
		headColor = appropriateBody.GetComponent<Avatar>().headColor;
		headLines = appropriateBody.GetComponent<Avatar>().headLines;
		pants = appropriateBody.GetComponent<Avatar>().pants;
		shirt = appropriateBody.GetComponent<Avatar>().shirt;
		shoes = appropriateBody.GetComponent<Avatar>().shoes;
		sclera = appropriateBody.GetComponent<Avatar>().sclera;
		iris = appropriateBody.GetComponent<Avatar>().iris;
	}
	
	private Color ArrayToColor (float[] colorArray) {
		return new Color(colorArray[0], colorArray[1], colorArray[2]);
	}
}
