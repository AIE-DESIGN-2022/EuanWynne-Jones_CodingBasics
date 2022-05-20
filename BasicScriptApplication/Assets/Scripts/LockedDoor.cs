using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{
    public string keyName;
    public InventoryManager _inventoryManager;
    public Text infoText;
    private bool _canOpenDoor;
    private bool _inTrigger;



    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = FindObjectOfType<InventoryManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //if player has key and E is pressed and is in the trigger turn door off
        if (_canOpenDoor == true && Input.GetKeyDown(KeyCode.E) == true && _inTrigger == true)
        {
            infoText.text = "";
            //turns the door off if both conditions are met
            transform.parent.gameObject.SetActive(false);


            _inventoryManager.UseItem(keyName);

            transform.parent.gameObject.SetActive(false);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //checks if the player is inside the triggers collider
        if (other.gameObject.tag == "Player")
        {
            _inTrigger = true;

            //aksing the inventory manager to check if the player has the key for the controller probably a door
            if (_inventoryManager.CheckInventoryForItem(keyName) == true)
            {
                //tell the player they can now unlock the object
                infoText.text = "Press E to open door!";
                //set a bool to allow the player to open object that we check for in update()
                _canOpenDoor = true;
            }

            else
            {

                //tell the player they need x speciic key
                infoText.text = "Door is locked you need a " + keyName;
            }
            

            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _inTrigger = false;
            infoText.text = "";
        }
    }
}
    
    

