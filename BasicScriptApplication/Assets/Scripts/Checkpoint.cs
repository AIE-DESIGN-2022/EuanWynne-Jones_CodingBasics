using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Killbox killbox;
    private void Start()
    {
        killbox = FindObjectOfType<Killbox>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
           {
            Color playercolour = other.gameObject.GetComponent<Renderer>().material.color;
            Debug.Log("Checkpoint Reached");
                killbox.UpdateCheckpointPosition(this.transform.position, playercolour);
            }
    }
}
