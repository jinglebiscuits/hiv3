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

	public Sprite[] headColors;
	public Sprite[] headLineses;

	private int head = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CycleHeads()
	{
		head ++;
		if(head >= headColors.Length)
			head = 0;
		headColor.sprite = headColors[head];
		headLines.sprite = headLineses[head];
	}

	void CreateProfileIcon()
	{

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
}
