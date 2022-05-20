using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour
{
    public string itemToUnlock;
    public int costOfItem;
    private bool _isInTrigger;
    private bool _canPurchaceItem;
    


    private CurrencyManager _currencyManager;
    private InventoryManager _inventoryManager;
    public Text infotext;
    // Start is called before the first frame update
    void Start()
    {
        //finds the currency manager in the scene
        _currencyManager = FindObjectOfType<CurrencyManager>();
        _inventoryManager = FindObjectOfType<InventoryManager>();

    }

    void Update()
    {
        if (_isInTrigger == true && _canPurchaceItem && Input.GetKeyDown(KeyCode.E))
        {
            //reduce cost of item from currency manager
            _currencyManager.RemoveCurrency(costOfItem);
            //add item to inventory
            _inventoryManager.AssignInventoryItem(itemToUnlock);
            //check currency amount ub comparison to cost of item
            _canPurchaceItem = CheckPlayerCurrency();
        }
    }

    private bool CheckPlayerCurrency()
    {
        if(_currencyManager.currentCurrencyAmount >= costOfItem)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //makes sure player is inside the shops colider
        if (other.gameObject.tag == "Player")
        {
            infotext.text = "Purchace " + itemToUnlock + " for $ " + costOfItem + "?";
            _isInTrigger = true;
            _canPurchaceItem = CheckPlayerCurrency();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           _isInTrigger = false;
           infotext.text = "";
        }
    }


   
}
