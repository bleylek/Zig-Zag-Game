using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject lastGround; // Reference to the last spawned ground piece

    // Start is called before the first frame update
    void Start()
    {
        // Spawn initial ground pieces
        for (int i = 0; i < 20; i++)
        {
            createGround();
        }
    }

    // Method to create a new ground piece
    public void createGround()
    {
        Vector3 direction;

        // Randomly determine whether the new ground piece will be in the forward or left direction
        if (Random.Range(0, 2) == 1)
        {
            direction = Vector3.forward;
        }
        else
        {
            direction = Vector3.left;
        }

        // Instantiate the new ground piece at the calculated position
        lastGround = Instantiate(lastGround, lastGround.transform.position + direction, lastGround.transform.rotation);
    }
}
