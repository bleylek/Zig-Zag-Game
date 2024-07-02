using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float addedSpeed;
    public GroundSpawner groundSpawnerScript;
    private Vector3 direction;
    public float speed;
    public static bool isDropped; // Static to allow access from other scripts

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.forward; // Set initial direction to forward
        isDropped = false; // Ball is not dropped initially
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.5f)
        {
            isDropped = true; // Ball has dropped
        }

        if (isDropped)
        {
            return; // Skip further processing if the ball has dropped
        }

        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            // Toggle direction between forward and left for zigzag movement
            if (direction.x == 0)
            {
                direction = Vector3.left; // Change direction to left
            }
            else
            {
                direction = Vector3.forward; // Change direction to forward
            }

            // Increment speed with addedSpeed, scaled by deltaTime
            speed += addedSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate() // Perform movement in FixedUpdate for physics consistency
    {
        Vector3 movement = direction * Time.deltaTime * speed; // Calculate movement
        transform.position += movement; // Apply movement to the ball's position
    }

    private void OnCollisionExit(Collision collision) // Handle collision exit
    {
        if (collision.gameObject.tag == "ground")
        {
            Score.score++; // Increment score
            collision.gameObject.AddComponent<Rigidbody>(); // Add Rigidbody to make the ground piece fall
            groundSpawnerScript.createGround(); // Spawn a new ground piece
            StartCoroutine(deleteGround(collision.gameObject)); // Start coroutine to delete the ground piece
        }
    }

    IEnumerator deleteGround(GameObject groundToBeDeleted) // Coroutine to delete ground piece
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        Destroy(groundToBeDeleted); // Delete the ground piece
    }
}
