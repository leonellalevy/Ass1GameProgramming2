using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public float distance = 5.0f; // Distance from the player
    public float height = 2.0f; // Height above the player
    public float rotationSpeed = 5.0f; // Camera rotation speed

    private Vector3 offset; // Offset from the player

    void Start()
    {
        offset = new Vector3(0.0f, height, -distance);
    }

    void LateUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = playerTransform.position + offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, rotationSpeed * Time.deltaTime);

        // Rotate the camera to always look at the player
        transform.LookAt(playerTransform.position);
    }
}
