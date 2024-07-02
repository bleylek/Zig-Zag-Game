using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform locationOfBall; // The ball's transform
    private Vector3 difference; // The initial difference between the camera and the ball

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the initial difference between the camera and the ball
        difference = transform.position - locationOfBall.position;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // Only follow the ball if it has not dropped
        if (!BallMovement.isDropped)
        {
            // Update the camera's position to follow the ball while maintaining the initial difference
            transform.position = locationOfBall.position + difference;
        }
    }
}
