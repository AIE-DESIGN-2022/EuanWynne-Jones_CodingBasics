using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public Vector3 checkpoint;
    public GameObject player;
    private Color colourAtCheckpoint;

    private void Start()
    {
        checkpoint = player.transform.position;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(checkpoint != null)
        {
            player.GetComponent<Renderer>().material.color = colourAtCheckpoint;
        other.transform.position = checkpoint;
        }

    }
    public void UpdateCheckpointPosition(Vector3 newPosition, Color playerColour)

    {
        checkpoint = newPosition;
        colourAtCheckpoint = playerColour;
    }
   
}
