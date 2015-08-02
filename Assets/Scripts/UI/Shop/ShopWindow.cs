using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/*This handles all things going on in the actual shop.
* There is another script that handles the showing and
* hiding of the shop.
*/
public class ShopWindow : MonoBehaviour {

	public Transform modalWindowPanel;
	public List<Item> cart = new List<Item>();
	private int cartTotal = 0;
	private bool canPurchase = false;
	
	public Text cartTotalText;
	public Text personCoinsText;
	
	public Button buyButton;
	public Button emptyCartButton;
	
	//player stuff
	private int coinsToSpend = 0;

	// Use this for initialization
	void Start () {
		GetPlayerCoins();
		CalculateCartTotal();
	}
	
	private bool CanPurchase {
		get {
			return this.canPurchase;
		}
		set {
			canPurchase = value;
			if (value) {
				buyButton.interactable = true;
			} else
				buyButton.interactable = false;
		}
	}
	
	public void ClearCart () {
		cart.Clear();
		CalculateCartTotal();
	}
	
	public void AddToCart (Item item) {
		cart.Add(item);
		CalculateCartTotal();
	}
	
	public void RemoveFromCart (Item item) {
		if (cart.Remove(item)) {
			CalculateCartTotal();
			Debug.Log ("successful removal");
		}
		else
			Debug.Log ("item not found. Didn't remove");
	}
	
	private int CalculateCartTotal () {
		int tempTotal = 0;
		
		foreach (Item item in cart) {
			tempTotal += item.Cost;
		}
		
		if (tempTotal <= GetPlayerCoins()) {
			CanPurchase = true;
		} else
			CanPurchase = false;
		
		cartTotal = tempTotal;
		cartTotalText.text = cartTotal.ToString();
		return tempTotal;
	}
	
	private int GetPlayerCoins () {
		int personCoins = Player.player.FocusedPerson.QualitiesDict["Coins"].Level;
		personCoinsText.text = personCoins.ToString();
		return personCoins;
	}
	
	public void Buy () {
		Person person = Player.player.FocusedPerson;
		foreach (Item item in cart) {
			person.QualitiesDict[item.Name].AddPoints(1);
		}
		cart.Clear();
		CalculateCartTotal();
	}
}
