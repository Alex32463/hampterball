using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 2;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(1); // Get the first touch

            // Check if the touch phase is the beginning of a touch
            if (touch.phase == TouchPhase.Began)
            {
                SceneManager.LoadScene("Main");
            }
        }
        var moveHorizontal = Input.acceleration.x;
        var moveVertical = Input.acceleration.y;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed * 2);
    }
}