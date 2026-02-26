using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class BallBounceSound : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;

    // Minimum impact speed needed to play sound (avoids playing sound when rolling)
    public float minVelocity = 1.0f;
    // Velocity magnitude that equals maximum volume (1.0)
    public float maxVelocity = 15.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Calculate the speed of the collision
        float impactSpeed = collision.relativeVelocity.magnitude;

        // Check if the hit is strong enough
        if (impactSpeed > minVelocity)
        {
            // Calculate volume based on impact speed (0.0 to 1.0)
            float volume = Mathf.Clamp01(impactSpeed / maxVelocity);

            // Set volume and play sound once
            audioSource.volume = volume;
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
