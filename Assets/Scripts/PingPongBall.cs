using UnityEngine;

public class PingPongBall : MonoBehaviour
{
    public float launchSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LaunchBall();
    }

    void LaunchBall()
    {
        rb.linearVelocity = transform.forward * launchSpeed;
    }
    
}
