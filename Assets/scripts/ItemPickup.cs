using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Pickup
{
    public GameController game;
    public Item item;

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
    } 

    public override void OnPickup()
    {
        game.OnItemPickup(item);
    }
}
