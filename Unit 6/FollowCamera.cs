using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target; // The GameObject to follow
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the target
    [SerializeField] private float smoothSpeed = 5f; // Smoothing factor

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("No target assigned to the camera.");
            return;
        }

        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}

