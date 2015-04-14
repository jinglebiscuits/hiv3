using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Story container is the area that contains all available stories. It sits in ScrollingRect so that the user can scroll through the stories.
/// </summary>
public class StoryContainer : MonoBehaviour {

	public GameObject storyViewPrefab;
	public GameObject trunkViewPrefab;
	public GameObject branchViewPrefab;
	public GameObject resultViewPrefab;
	public List<GameObject> storyViews = new List<GameObject>();
	public List<GameObject> branchViews = new List<GameObject>();
	public GameObject trunkView = null;
	public GameObject resultView = null;

	public float storyHeight;
	public float padding;
	//public Forest forest = new Forest();
	public Person person;
	public Manager manager;

	void Awake ()
	{

	}

	// Use this for initialization
	void Start ()
	{

	}

	public void MainSceneStart()
	{
		person = GameObject.Find("Player").GetComponent<Player>().FocusedPerson;
		//manager = GameObject.Find("Manager").GetComponent<Manager>();
		storyHeight = -2*storyViewPrefab.GetComponent<RectTransform>().anchoredPosition.y;
		padding = storyHeight*-0.1f;
	}

	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Shows the stories. Currently just displaying garbage 1/7/15
	/// </summary>
	public void ShowStories()
	{
		WipeViews();
		manager.UpdateTrunks();
		int count = 0;
		//foreach(Story story in forest.trunks)
		foreach(Story story in person.AvailableTrunks)
		{
			GameObject clone = (GameObject) Instantiate(storyViewPrefab);
			clone.GetComponent<StoryView>().Story = story;
			clone.transform.SetParent(this.transform, false);
			clone.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, count * (-storyHeight + padding));
			storyViews.Add(clone);
			count ++;
		}

		transform.parent.GetComponent<BrowseStoriesView>().ResetScrollToTop();
	}

	public void ShowBranches(Trunk trunk)
	{
		WipeViews();
		trunkView = (GameObject) Instantiate(trunkViewPrefab);
		trunkView.GetComponent<TrunkView>().Trunk = trunk;
		trunkView.transform.SetParent(this.transform, false);
		int count = 1;
		foreach(Branch branch in trunk.Branches)
		{
			//Create and place a BranchView prefab
			GameObject clone = (GameObject) Instantiate(branchViewPrefab);
			clone.GetComponent<BranchView>().Branch = branch;
			clone.transform.SetParent(this.transform, false);
			clone.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, count * (-storyHeight + padding));
			branchViews.Add (clone);
			count ++;
		}

		transform.parent.GetComponent<BrowseStoriesView>().ResetScrollToTop();
	}

	public void ShowResult(Result result)
	{
		WipeViews();
		resultView = (GameObject) Instantiate(resultViewPrefab);
		resultView.GetComponent<ResultView>().Result = result;
		resultView.transform.SetParent(this.transform, false);

		transform.parent.GetComponent<BrowseStoriesView>().ResetScrollToTop();
	}

	private void WipeViews()
	{
		foreach(GameObject story in storyViews)
		{
			Destroy(story);
		}
		storyViews.Clear();

		foreach(GameObject branch in branchViews)
		{
			Destroy(branch);
		}
		branchViews.Clear();
		if(trunkView != null)
			Destroy(trunkView);
		if(resultView != null)
			Destroy(resultView);
	}
}
