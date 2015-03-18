using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

	public GameObject fullFemaleView;
	public GameObject fullMaleView;

	public Sprite profilePicSprite = new Sprite();
	private Texture2D newBodyTexture;
	private Vector2 bottomLeft = new Vector2(0, 1226);

	public Sprite[] headColors;
	public Sprite[] headLineses;

	private int head = 0;

	// Use this for initialization
	void Start () {

//		profilePicSprite = Sprite.Create(CalculateTexture(1869, 589, 30, 294, 1500, body.sprite.texture), new Rect(0, 0, 100, 100), new Vector2(50, 50));
	}
	
	// Update is called once per frame
	void LateUpdate () {

	}

	public void CycleHeads()
	{
		head ++;
		if(head >= headColors.Length)
			head = 0;
		headColor.sprite = headColors[head];
		headLines.sprite = headLineses[head];
	}

	public void CreateProfileIcon()
	{
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

		newBodyTexture = MakeBorder();
		profilePicSprite = Sprite.Create(newBodyTexture, new Rect(0, 0, newBodyTexture.width, newBodyTexture.height), new Vector2(0.5f, 0.5f));
		profilePicSprite.name = "profilePick";
		profileBorder.sprite = profilePicSprite;
		profileBorder.color = Color.white;

		newBodyTexture = MakeBackground();
		profilePicSprite = Sprite.Create(newBodyTexture, new Rect(0, 0, newBodyTexture.width, newBodyTexture.height), new Vector2(0.5f, 0.5f));
		profilePicSprite.name = "profilePick";
		profileBackground.sprite = profilePicSprite;
		profileBackground.color = Color.white;
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
