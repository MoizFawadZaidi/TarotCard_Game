using System.Collections;
using global::UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : UnityEngine.MonoBehaviour
{
    public float moveSpeed = 5f;
    private UnityEngine.Rigidbody2D rb;
    private UnityEngine.Vector2 input;
    
    void Start()
    {
        rb = GetComponent<UnityEngine.Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float vertical = 0f;

        if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.UpArrow))
        {
            rb.rotation = 15f;
            vertical = 1f;
        }
        else if (UnityEngine.Input.GetKey(UnityEngine.KeyCode.DownArrow))
        {
            rb.rotation = -15f;
            vertical = -1f;
        }
        else
        {
            rb.rotation = 0f;
        }

        input = new UnityEngine.Vector2(0, vertical);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new UnityEngine.Vector2(0, input.y * moveSpeed);
    }
}
