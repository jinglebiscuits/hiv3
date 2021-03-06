﻿//Updates to this list require an update
//to the xml schema and xml files.
using System;

[Serializable]
public class BaseItems {

	public Item coins = new Item("Coins", "Buy stuff with coins.", 100, 0, 1, false);
	public Item tools = new Item("Tools", "Get paid", 0, 0, 100, false);
	public Item clothes = new Item("Clothes", "Looking good", 0, 0, 60, false);
	public Item books = new Item("Books", "Who needs tv?", 0, 0, 10, false);
	public Item games = new Item("Games", "You'll never be bored again", 0, 0, 60, false);
	public Item cellPhone = new Item("Cell Phone", "Kick start your social life", 0, 0, 200, false);
	public Item condoms = new Item("Condoms", "Way to go", 0, 0, 3, false);
	public Item birthControl = new Item("Birth Control", "That's the ticket", 0, 0, 2, false);
	public Item sportsEquipment = new Item("Sports Equipment", "Level up!", 0, 0, 30, false);
	public Item songs = new Item("Songs", "Level up!", 0, 0, 1, false);
	public Item flowers = new Item("Flowers", "Level up!", 0, 0, 10, false);
	
	public Item[] items;
	
	public BaseItems()
	{
		items = new Item[]{coins, tools, clothes, books, games, cellPhone, condoms, birthControl, sportsEquipment, songs, flowers};
	}
}
