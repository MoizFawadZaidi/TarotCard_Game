using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    private float width;
    public Transform pair;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (transform.position.x <= -width)
        {
            transform.position = pair.position + Vector3.right * width;
        }
    }
}
