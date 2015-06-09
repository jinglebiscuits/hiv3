using UnityEngine;
using System.Collections;

public class ViewManager : MonoBehaviour {
	
	public CharacterStatsView characterStatsView;
    public StatusView statusView;
    public FriendsView friendsView;
    public MentorsView mentorsView;
		
	// Use this for initialization
	void Start () {
//		characterStatsView.BaseAttributes = GameObject.Find("Player").GetComponent<Player>().FocusedPerson.BaseAttributes;
//		characterStatsView.ViewConstructor();
	}

	void OnLevelWasLoaded(int level)
	{

	}

	public void MainSceneStart(GameObject player)
	{
        Person person = player.GetComponent<Player>().FocusedPerson;

		characterStatsView = GameObject.Find ("CharacterStatsView").GetComponent<CharacterStatsView>();
		characterStatsView.BaseAttributes = person.BaseAttributes;
		characterStatsView.ViewConstructor();

        statusView = GameObject.Find ("StatusView").GetComponent<StatusView>();
        statusView.ViewConstructor(person);

        friendsView = GameObject.Find ("FriendsView").GetComponent<FriendsView>();
        friendsView.ViewConstructor(person);

        mentorsView = GameObject.Find ("MentorsView").GetComponent<MentorsView>();
        mentorsView.ViewConstructor(person);
	}
}
