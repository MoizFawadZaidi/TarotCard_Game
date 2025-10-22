using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
            // Game manager sets to game over
        }
    }
}
