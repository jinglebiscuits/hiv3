using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MentorsView : MonoBehaviour {

    private Person person;
    private List<Relationship> sortingList = new List<Relationship>();
    public List<Image> mentors = new List<Image>();
    public List<Sprite> mentorImages = new List<Sprite>();
    public Dictionary<string, Sprite> mentorsDict = new Dictionary<string, Sprite>();
    private int mentorsInGame = 5;

	// Use this for initialization
	public void ViewConstructor (Person person) {
        this.person = person;
        mentorsDict.Add("Auntie Gina", mentorImages[0]);
        mentorsDict.Add("Coach Woodfin", mentorImages[1]);
        mentorsDict.Add("Mrs. Lake", mentorImages[2]);
        mentorsDict.Add("Nurse Roberts", mentorImages[3]);
        mentorsDict.Add("Uncle Harry", mentorImages[4]);

        sortingList.Add((person.QualitiesDict["Auntie Gina"] as Relationship));
        sortingList.Add((person.QualitiesDict["Coach Woodfin"] as Relationship));
        sortingList.Add((person.QualitiesDict["Mrs. Lake"] as Relationship));
        sortingList.Add((person.QualitiesDict["Nurse Roberts"] as Relationship));
        sortingList.Add((person.QualitiesDict["Uncle Harry"] as Relationship));

        foreach(KeyValuePair<string, Sprite> entry in mentorsDict) {
            (person.QualitiesDict[entry.Key] as Relationship).pointEvent -= UpdateRelationship;
            (person.QualitiesDict[entry.Key] as Relationship).pointEvent += UpdateRelationship;
        }
        UpdateRelationship(null);
	}

    public void UpdateRelationship(string name) {
        IEnumerable<Relationship> query = sortingList.OrderBy(relationship => relationship.FriendPoints);

        int count = mentorsInGame - 1;
        foreach (Relationship relationship in query)
        {
            if(relationship.FriendPoints > 0) {
                mentors[count].sprite = mentorsDict[relationship.Name];
            }
            count --;
        }
    }
}
