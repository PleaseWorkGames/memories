using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListing 
{
	public int quantity;
	public Item item;

	public ItemListing(Item item) 
	{
		this.item = item;
		quantity = 1;
	}
}

public class Inventory : MonoBehaviour {
	
	public List<ItemListing> itemList;

	void Start() 
	{
		itemList = new List<ItemListing> ();
	}

	public void add(Item item) 
	{ 
		bool found = false;
		
		itemList = new List<ItemListing> ();
		foreach (ItemListing listing in itemList) {
			if (listing.item.name == item.name) {
				found = true;
				listing.quantity++;
				break;
			}
		}
		
		if (!found) {
			itemList.Add (new ItemListing (item));
		}
	}

	public void remove(string name) 
	{
		foreach (ItemListing listing in itemList) {
			if (listing.item.name == name) {
				listing.quantity--;
				if (listing.quantity < 1) {
					itemList.Remove (listing);
				}
				break;
			}
		}
	}
}
