using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroScrollingPanel : MonoBehaviour {

	public int screenWidth = 1280;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Next()
	{
		gameObject.GetComponent<RectTransform>().anchoredPosition -= new Vector2(screenWidth, 0);
	}

	public void Previous()
	{
		gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(screenWidth, 0);
	}
}
