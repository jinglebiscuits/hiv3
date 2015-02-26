using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Collections;

public class ColorPicker : MonoBehaviour{

	public Image image;
	public Texture2D texture;
	public Color pickedColor;
	public CanvasScaler canvasScaler;

	public int targetScreenWidth = 1280;//has to be updated for each device the game runs on

	//delete the following once things are set up right
	public Image body;
	public Image head;

	// Use this for initialization
	void Start () {
		texture = image.sprite.texture;
		int y = 0;
		while (y < texture.height) {
			int x = 0;
			while (x < texture.width) {
				//Color color = ((x & y) ? Color.white : Color.gray);
				Color color = EditorGUIUtility.HSVToRGB((float) 23/359, (float) x/texture.width, (float) y/texture.height);
				texture.SetPixel(x, y, color);
				++x;
			}
			++y;
		}
		texture.Apply();

		print(image.sprite.texture.height);
	}
	
	public void PickColor()
	{
		Vector2 clickSpot = Input.mousePosition;
		clickSpot -= (Vector2) gameObject.transform.parent.GetComponent<RectTransform>().position;
//		print (this.gameObject.GetComponent<RectTransform>().sizeDelta.x);
//		print (canvasScaler.scaleFactor);
//		print (Screen.width/1280.0f);
//		print (clickSpot / canvasScaler.scaleFactor / (Screen.width/1280.0f));
//		print ("image size: " + this.gameObject.GetComponent<RectTransform>().sizeDelta.x * canvasScaler.scaleFactor / Screen.width/1280.0f);
		clickSpot = clickSpot * ((float) texture.width / (float) this.gameObject.GetComponent<RectTransform>().sizeDelta.x) / canvasScaler.scaleFactor / ((float) Screen.width/targetScreenWidth);
		print (clickSpot);
		pickedColor = texture.GetPixel((int) clickSpot.x, (int) (256 + clickSpot.y));
		body.color = pickedColor;
		head.color = pickedColor;
	}
}
