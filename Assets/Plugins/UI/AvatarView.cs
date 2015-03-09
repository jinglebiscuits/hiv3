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

	private Image hairProfile;
	private Image bodyProfile;
	private Image headColorProfile;
	private Image headLinesProfile;
	private Image pantsProfile;
	private Image shirtProfile;
	private Image shoesProfile;
	private Image scleraProfile;
	private Image irisProfile;
	private Image lipsProfile;

	public Image profilePic;
	public Sprite profilePicSprite = new Sprite();
	private Texture2D newBodyTexture;
	public Rect readPixelRect;
	public Material testMaterial;


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
		Color[] pix = hair.sprite.texture.GetPixels(0, 0, hair.sprite.texture.width, hair.sprite.texture.height);
		newBodyTexture = new Texture2D(hair.sprite.texture.width, hair.sprite.texture.height, TextureFormat.RGBA32, false);
		newBodyTexture.SetPixels(pix);
//		newBodyTexture = Instantiate(body.sprite.texture) as Texture2D;


//		newBodyTexture = new Texture2D(body.sprite.texture.width, body.sprite.texture.height, TextureFormat.ARGB32, true);
//		
//		int y = 0;
//		while (y < body.sprite.texture.height) {
//			int x = 0;
//			while (x < body.sprite.texture.width) {
//				newBodyTexture.SetPixel(x, y, body.sprite.texture.GetPixel(x, y));
//				++x;
//			}
//			++y;
//		}
		newBodyTexture.Apply();
		profilePicSprite = Sprite.Create(newBodyTexture, new Rect(0, 0, newBodyTexture.width, newBodyTexture.height), new Vector2(0.5f, 0.5f));
		profilePicSprite.name = "profilePick";
		profilePic.sprite = profilePicSprite;
		print(profilePic.GetComponent<RectTransform>().sizeDelta);
		GameObject quad = GameObject.Find ("SpriteTest");
		quad.GetComponent<SpriteRenderer>().sprite = profilePic.sprite;
		testMaterial.color = Color.red;
		testMaterial.mainTexture = newBodyTexture;
	}

	Texture2D CalculateTexture(
		int h, int w,float r,float cx,float cy,Texture2D sourceTex
		){
		Color [] c= sourceTex.GetPixels(0, 0, sourceTex.width, sourceTex.height);
		Texture2D b=new Texture2D(h,w);
		for (int i = 0 ; i<(h*w);i++){
			int y=Mathf.FloorToInt(((float)i)/((float)w));
			int x=Mathf.FloorToInt(((float)i-((float)(y*w))));
			if (r*r>=(x-cx)*(x-cx)+(y-cy)*(y-cy)){
				b.SetPixel(x, y, c[i]);
			}else{
				b.SetPixel(x, y, Color.clear);
			}
		}
		b.Apply ();
		return b;
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(10, 10, 60, 60), profilePicSprite.texture, ScaleMode.ScaleToFit);
	}
}
