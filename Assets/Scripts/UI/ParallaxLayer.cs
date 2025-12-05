using global::UnityEngine;

public class ParallaxLayer : UnityEngine.MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        transform.position += UnityEngine.Vector3.left * speed * UnityEngine.Time.deltaTime;
    }
}

