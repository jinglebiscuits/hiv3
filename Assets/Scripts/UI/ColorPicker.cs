using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour{

	public Image image;
	public Texture2D texture;
	public Color pickedColor;
	public CanvasScaler canvasScaler;
	public RectTransform avatarPanel;
	public Image selectedImage;
	public Slider hueSlider;
	public float hValue;
	
	private bool hair = false, eyes = false, lips = false, shirt = false, pants = false, shoes = false;

	public int targetScreenWidth = 1280;//has to be updated for each device the game runs on
	

	// Use this for initialization
	void Start () {
		texture = image.sprite.texture;
		int y = 0;
		while (y < texture.height) {
			int x = 0;
			while (x < texture.width) {
				Color color = HSVToRGB((float) hValue/359, (float) x/texture.width, (float) y/texture.height);
				texture.SetPixel(x, y, color);
				++x;
			}
			++y;
		}
		texture.Apply();
	}

	public bool Hair {
		get {
			return this.hair;
		}
		set {
			this.hair = value;
			ChangeSelectedImage();
		}
	}
	
	public bool Eyes {
		get {
			return this.eyes;
		}
		set {
			this.eyes = value;
			ChangeSelectedImage();
		}
	}
	
	public bool Lips {
		get {
			return this.lips;
		}
		set {
			this.lips = value;
			ChangeSelectedImage();
		}
	}
	
	public bool Shirt {
		get {
			return this.shirt;
		}
		set {
			this.shirt = value;
			ChangeSelectedImage();
		}
	}
	
	public bool Pants {
		get {
			return this.pants;
		}
		set {
			this.pants = value;
			ChangeSelectedImage();
		}
	}
	
	public bool Shoes {
		get {
			return this.shoes;
		}
		set {
			this.shoes = value;
			ChangeSelectedImage();
		}
	}

	public void UpdateHue()
	{
		hValue = hueSlider.value;
		texture = image.sprite.texture;
		int y = 0;
		while (y < texture.height) {
			int x = 0;
			while (x < texture.width) {
				Color color = HSVToRGB((float) hValue/359, (float) x/texture.width, (float) y/texture.height);
				texture.SetPixel(x, y, color);
				++x;
			}
			++y;
		}
		texture.Apply();
	}

	public void ChangeBodyColor()
	{
		Vector2 clickSpot = Input.mousePosition;
		clickSpot -= (Vector2) gameObject.transform.parent.GetComponent<RectTransform>().position;
		clickSpot = clickSpot * ((float) texture.width / (float) this.gameObject.GetComponent<RectTransform>().sizeDelta.x) / canvasScaler.scaleFactor / ((float) Screen.width/targetScreenWidth);
		pickedColor = texture.GetPixel((int) clickSpot.x, (int) (256 + clickSpot.y));
		avatarPanel.GetComponent<AvatarView>().body.color = pickedColor;
		if(avatarPanel.GetComponent<AvatarView>().headColor)
			avatarPanel.GetComponent<AvatarView>().headColor.color = pickedColor;
		else
			avatarPanel.GetComponent<AvatarView>().headLines.color = pickedColor;
	}

	public void ChangeSelectedImageColor()
	{
		if (selectedImage) {
			Vector2 clickSpot = Input.mousePosition;
			clickSpot -= (Vector2) gameObject.transform.parent.GetComponent<RectTransform>().position;
			clickSpot = clickSpot * ((float) texture.width / (float) this.gameObject.GetComponent<RectTransform>().sizeDelta.x) / canvasScaler.scaleFactor / ((float) Screen.width/targetScreenWidth);
			pickedColor = texture.GetPixel((int) clickSpot.x, (int) (256 + clickSpot.y));
			selectedImage.color = pickedColor;
		}
	}

	public void ChangeSelectedImage()
	{
		if (hair)
			selectedImage = avatarPanel.GetComponent<AvatarView>().hair;
		else if (eyes)
			selectedImage = avatarPanel.GetComponent<AvatarView>().iris;
		else if (lips)
			selectedImage = avatarPanel.GetComponent<AvatarView>().lips;
		else if (shirt)
			selectedImage = avatarPanel.GetComponent<AvatarView>().shirt;
		else if (pants)
			selectedImage = avatarPanel.GetComponent<AvatarView>().pants;
		else if (shoes)
			selectedImage = avatarPanel.GetComponent<AvatarView>().shoes;
		else
			selectedImage = null;
	}

	public static Color HSVToRGB(float H, float S, float V)
	{
		if (S == 0f)
			return new Color(V,V,V);
		else if (V == 0f)
			return Color.black;
		else
		{
			Color col = Color.black;
			float Hval = H * 6f;
			int sel = Mathf.FloorToInt(Hval);
			float mod = Hval - sel;
			float v1 = V * (1f - S);
			float v2 = V * (1f - S * mod);
			float v3 = V * (1f - S * (1f - mod));
			switch (sel + 1)
			{
			case 0:
				col.r = V;
				col.g = v1;
				col.b = v2;
				break;
			case 1:
				col.r = V;
				col.g = v3;
				col.b = v1;
				break;
			case 2:
				col.r = v2;
				col.g = V;
				col.b = v1;
				break;
			case 3:
				col.r = v1;
				col.g = V;
				col.b = v3;
				break;
			case 4:
				col.r = v1;
				col.g = v2;
				col.b = V;
				break;
			case 5:
				col.r = v3;
				col.g = v1;
				col.b = V;
				break;
			case 6:
				col.r = V;
				col.g = v1;
				col.b = v2;
				break;
			case 7:
				col.r = V;
				col.g = v3;
				col.b = v1;
				break;
			}
			col.r = Mathf.Clamp(col.r, 0f, 1f);
			col.g = Mathf.Clamp(col.g, 0f, 1f);
			col.b = Mathf.Clamp(col.b, 0f, 1f);
			return col;
		}
	}
}
