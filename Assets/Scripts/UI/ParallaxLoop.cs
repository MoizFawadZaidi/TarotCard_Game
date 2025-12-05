using global::UnityEngine;

public class ParallaxLoop : UnityEngine.MonoBehaviour
{
    private float width;
    public UnityEngine.Transform pair;

    void Start()
    {
        width = GetComponent<UnityEngine.SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (transform.position.x <= -width)
        {
            transform.position = pair.position + UnityEngine.Vector3.right * width;
        }
    }
}
