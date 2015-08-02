using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemView : MonoBehaviour {
	
	private Item item;
	
	public string itemName;
	public Text costText;
	public Text numberInCartText;
	public int numberInCart = 0;
	
	public ShopWindow shopWindow;

	// Use this for initialization
	void Start () {
		item = (Item) Player.player.FocusedPerson.QualitiesDict[itemName];
		costText.text = item.Cost.ToString();
		numberInCartText.text = "x " + numberInCart;
	}
	
	public int NumberInCart {
		get {
			return this.numberInCart;
		}
		set {
			numberInCart = value;
			numberInCartText.text = "x " + numberInCart;
		}
	}
	
	//This will always work. Let the ShopWindow handle the logic
	public void AddToCart () {
		shopWindow.AddToCart (item);
		numberInCart ++;
		numberInCartText.text = "x " + numberInCart;
	}
	
	public void RemoveFromCart () {
		shopWindow.RemoveFromCart (item);
		numberInCart = System.Math.Max(0, numberInCart - 1);
		numberInCartText.text = "x " + numberInCart;
	}
}
