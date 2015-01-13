using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// Story container is the area that contains all available stories. It sits in ScrollingRect so that the user can scroll through the stories.
/// </summary>
public class StoryContainer : MonoBehaviour {

	public GameObject storyViewPrefab;
	public float storyHeight;
	public float padding;

	// Use this for initialization
	void Start ()
	{
		storyHeight = -2*storyViewPrefab.GetComponent<RectTransform>().anchoredPosition.y;
		padding = storyHeight*-0.1f;
		ShowStories();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Shows the stories. Currently just displaying garbage 1/7/15
	/// </summary>
	private void ShowStories()
	{
		int count = 0;
		for(int i = 0; i < 6; i++)
		{
			GameObject clone = (GameObject) Instantiate(storyViewPrefab);
			clone.GetComponent<StoryView>().story = null; //this should be a specific story or branch.
			clone.transform.SetParent(this.transform, false);
			clone.GetComponent<RectTransform>().position += new Vector3(0, count * (-storyHeight + padding), 0);
			count ++;
		}
	}
}
