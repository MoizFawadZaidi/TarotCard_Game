using System.Collections;
using UnityEngine;


public class PlayerMovmentScript : MonoBehaviour
{
    [SerializeField] private Vector2 topLane = new Vector2 (-5f, 1.5f);
    [SerializeField] private Vector2 bottomLane = new Vector2(-5f, -3f);
    [SerializeField] private float moveDuration = 1f;
    private Coroutine moveCoroutine;

    [SerializeField] private AudioClip moveSoundClip;

    private bool isMoving = false; // Lock inputs whilst moving


    // Update is called once per frame
    void Update()
    {
        if (isMoving) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(SmoothMove(topLane));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(SmoothMove(bottomLane));
        }
    }

    IEnumerator SmoothMove(Vector2 target)
    {
        isMoving = true;
        SoundFXManager.instance.PlaySoundFXClip(moveSoundClip, transform, 0.1f);

        Vector2 start = transform.position;
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / moveDuration);
            transform.position = Vector2.Lerp (start, target, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
        transform.position = target; 
        isMoving = false; 
    }
}
