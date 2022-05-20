using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<string> inventoryItemNames;
    public Text inventoryListText;
    public GameObject inventoryPanel;

    private void Start()
    {
        //sets panel off at start
        inventoryPanel.SetActive(false);
        inventoryListText.text = "";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //sets panel active or inavtive depending on current state
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
            //if it is active update the text inside
         
        }
    }
    public void AssignInventoryItem(string _itemPickedUp)
        {
            //add the item that was picked up to the list
            inventoryItemNames.Add(_itemPickedUp);
            UpdateInventoryText();
    }
        private void UpdateInventoryText()
        {
            //Clearing previous text before adding new items to list
            inventoryListText.text = "";

            //For each loop adds each item in the list for every item
            foreach (string _inventoryItem in inventoryItemNames)
            {
                //creates each item on a new line
                inventoryListText.text += _inventoryItem + "\n";

            }
        }
    public bool CheckInventoryForItem(string _itemToCheck)
    {
        //run through each item in inventroy list to check if the name of the key is present
        //name passed in (_ItemToCheck) matches item in inventory

        foreach(string _inventoryItem in inventoryItemNames)
        {
            Debug.Log(_itemToCheck + "       " + _inventoryItem);
            //check if the inventory item that we are upto is the required item
            if(_inventoryItem == _itemToCheck) 
            {
             
                return true;
            }
            
        }
        //if the item is never found in the list return false
        return false;


    }
    public void UseItem(string _itemToCheck)
    {
        bool _foundItem = false;

        foreach (string _inventoryItem in inventoryItemNames)
        {
            //checks if the item names match
            if (_inventoryItem == _itemToCheck)
            {
                _foundItem = true;

            }
        }
        //After look has finished then remove item from inventory
                // removes item from inventory
        if (_foundItem)
        {
            inventoryItemNames.Remove(_itemToCheck);
            //update inventory text
            UpdateInventoryText();
        }
    }
}

