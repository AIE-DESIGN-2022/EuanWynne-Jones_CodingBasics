using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
   
    public Transform pickupPoint;
    public Text infoText;
    private InventoryManager _inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        //Clears info text box
        infoText.text = "";

        //Looking through objects in scene to find ones with inventory manager script on them
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
        infoText.text = "Press E to Pickup!";
            if (Input.GetKey(KeyCode.E))
            {
                /*
                other.GetComponent<Collider>().enabled = false;
                other.transform.position = pickupPoint.position;
                other.transform.parent = this.transform;
                */





                //calling into function on inventory manager to add the picked up item to the list
                //passing the collider object.gameobject to it 
                infoText.text = "";
                _inventoryManager.AssignInventoryItem(other.gameObject.name);
                 //after picked up destroys the object from the scene
                 Destroy(other.gameObject);
            
            }
            
            
        }
        
    }

    //when leaving the trigger makes the text disappear
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            infoText.text = "";
        }
    }
}
