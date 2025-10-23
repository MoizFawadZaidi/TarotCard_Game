using System.Collections;
using UnityEngine;


public class PlayerMovmentScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           gameObject.transform.position = new Vector2(-5f, 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position = new Vector2(-5f, -3f);
        }
    }
}
