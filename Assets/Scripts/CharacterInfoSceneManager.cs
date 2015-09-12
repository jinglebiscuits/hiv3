using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterInfoSceneManager : MonoBehaviour {

	public Text toolsCount;
	public Text clothesCount;
	public Text booksCount;
	public Text gamesCount;
	public Text condomsCount;
	public Text birthControlCount;
	public Text sportsEquipmentCount;
	public Text songCount;
	public Text flowersCount;
	
	private Dictionary<string, Text> itemLookup = new Dictionary<string, Text>();
	
	// Use this for initialization
	void Start () {
		Person person = Player.player.FocusedPerson;
		itemLookup.Add("Tools", toolsCount);
		itemLookup.Add("Clothes", clothesCount);
		itemLookup.Add("Books", booksCount);
		itemLookup.Add("Games", gamesCount);
		itemLookup.Add("Condoms", condomsCount);
		itemLookup.Add("Birth Control", birthControlCount);
		itemLookup.Add("Sports Equipment", sportsEquipmentCount);
		itemLookup.Add("Songs", songCount);
		itemLookup.Add("Flowers", flowersCount);
		
		foreach (Item item in person.BaseItems.items) {
			if (itemLookup.ContainsKey(item.Name)) {
				itemLookup[item.Name].text = 
				person.QualitiesDict[item.Name].Level.ToString();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
