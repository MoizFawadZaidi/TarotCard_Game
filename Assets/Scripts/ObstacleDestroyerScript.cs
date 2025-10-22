using UnityEngine;

public class ObstacleDestroyerScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            Destroy(other.gameObject);
            Debug.Log("Object destroyed");
        }
    }
}
