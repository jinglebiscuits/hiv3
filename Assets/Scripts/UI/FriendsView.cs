using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class FriendsView : MonoBehaviour {

    private Person person;
    private List<Relationship> sortingList = new List<Relationship>();
    public List<Image> friends = new List<Image>();
    public List<Sprite> friendImages = new List<Sprite>();
    public Dictionary<string, Sprite> friendsDict = new Dictionary<string, Sprite>();
    private int friendsInGame = 4;

	// Use this for initialization
	public void ViewConstructor (Person person) {
        this.person = person;
        friendsDict.Add("Monique", friendImages[0]);
        friendsDict.Add("Jimmy", friendImages[1]);
        friendsDict.Add("Jay Jay", friendImages[2]);
        friendsDict.Add("Tia", friendImages[3]);

        sortingList.Add((person.QualitiesDict["Monique"] as Relationship));
        sortingList.Add((person.QualitiesDict["Jimmy"] as Relationship));
        sortingList.Add((person.QualitiesDict["Jay Jay"] as Relationship));
        sortingList.Add((person.QualitiesDict["Tia"] as Relationship));

        foreach(KeyValuePair<string, Sprite> entry in friendsDict) {
            (person.QualitiesDict[entry.Key] as Relationship).pointEvent -= UpdateRelationship;
            (person.QualitiesDict[entry.Key] as Relationship).pointEvent += UpdateRelationship;
        }
        UpdateRelationship(null);
	}

    public void UpdateRelationship(string name) {
        IEnumerable<Relationship> query = sortingList.OrderBy(relationship => relationship.FriendPoints);

        int count = friendsInGame - 1;
        foreach (Relationship relationship in query)
        {
            if(relationship.FriendPoints > 0) {
                friends[count].sprite = friendsDict[relationship.Name];
            }
            count --;
        }
    }
}
