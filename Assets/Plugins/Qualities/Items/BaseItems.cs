public class BaseItems {
	
	public Item tools = new Item("Tools", "Get paid", 0, 0, 1, false);
	public Item clothes = new Item("Clothes", "Looking good", 0, 0, 1, false);
	public Item books = new Item("Books", "Who needs tv?", 0, 0, 1, false);
	public Item games = new Item("Games", "You'll never be bored again", 0, 0, 1, false);
	public Item cellPhone = new Item("Cell Phone", "Kick start your social life", 0, 0, 1, false);
	public Item condoms = new Item("Condoms", "Way to go", 0, 0, 1, false);
	public Item birthControl = new Item("Birth Control", "That's the ticket", 0, 0, 1, false);
	
	public Item[] items;
	
	public BaseItems()
	{
		items = new Item[]{tools, clothes, books, games, cellPhone, condoms, birthControl};
	}
}
