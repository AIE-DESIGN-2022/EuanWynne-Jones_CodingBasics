using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndZone : MonoBehaviour
{

    public GameObject endZonePanel;
    // Start is called before the first frame update
    void Start()
    {
    endZonePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            endZonePanel.SetActive(true);
        }
    }
    public void RestartLvl()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

