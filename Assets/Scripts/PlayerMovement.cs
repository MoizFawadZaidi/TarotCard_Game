using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 input;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float vertical = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.rotation = 15f;
            vertical = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.rotation = -15f;
            vertical = -1f;
        }
        else
        {
            rb.rotation = 0f;
        }

        input = new Vector2(0, vertical);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, input.y * moveSpeed);
    }
}
