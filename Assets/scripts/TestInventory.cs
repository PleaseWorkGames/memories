using UnityEngine;
using UnityEngine.UI;

public class TestInventory : MonoBehaviour
{
    public InputField itemField;
    public GameController game;

    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController")
            .gameObject
            .GetComponent<GameController>();
        itemField = GameObject.Find("TestInventory").transform.GetChild(0)
            .gameObject
            .GetComponent<InputField>();
    } 

    // Fires onClick method on button
    public void enterItem()
    {
        Debug.Log("clicked!");
        Item enteredItem = new Item(1, itemField.text, "item");
        game.OnItemPickup(enteredItem);
        itemField.text = "";
    }
}