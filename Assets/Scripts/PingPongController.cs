using UnityEngine;

public class PingPongController : MonoBehaviour
{
    public Camera mainCamera;          
    public float moveSpeed = 10f;      

    private Rigidbody rb;
    
    private Plane movementPlane;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        movementPlane = new Plane(Vector3.up, transform.position);
    }

    void FixedUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        float enter;
        if (movementPlane.Raycast(ray, out enter))
        {
            Vector3 targetPoint = ray.GetPoint(enter);
            Vector3 currentPosition = transform.position;
            
            Vector3 direction = (targetPoint - currentPosition);
            direction.y = 0f; 

           
            Vector3 desiredVelocity = direction.normalized * moveSpeed;

            
            if (direction.magnitude < 0.1f)
            {
                desiredVelocity = Vector3.zero;
            }
            
            rb.linearVelocity = desiredVelocity;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}

