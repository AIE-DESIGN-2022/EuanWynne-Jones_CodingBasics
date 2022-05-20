using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour
{
   
    public Transform pickupPoint;
    public Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        infoText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        infoText.text = "Press E to Pickup!";
        if (other.gameObject.tag == "Pickup")
        {
            if (Input.GetKey(KeyCode.E))
            {
            other.GetComponent<Collider>().enabled = false;
            other.transform.position = pickupPoint.position;
            other.transform.parent = this.transform;
            infoText.enabled = false;
            infoText.text = "";
            }

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            infoText.text = "";
        }
    }
}
