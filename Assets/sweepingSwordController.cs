using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sweepingSwordController : MonoBehaviour
{
    private Quaternion startRotation; // Variable to store the initial rotation
    public float spinDuration = 1.0f; // Duration for one full spin (360 degrees)

    void Start()
    {
        // Cache the initial rotation
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 360f * (Time.time % spinDuration) / spinDuration;
        transform.rotation = startRotation * Quaternion.Euler(0, 0, angle);
    }

   
}
