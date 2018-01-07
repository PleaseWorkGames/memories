using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Player"))
		{
			return;
		}
		OnPickup();
		Destroy(gameObject);
		
	}
	
	// What to do before the object is destroyed
	abstract public void OnPickup();
}
