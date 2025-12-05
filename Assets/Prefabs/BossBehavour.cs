using System.Collections;
using System.Collections.Generic;
using global::UnityEngine;


public class BossBehavour : UnityEngine.MonoBehaviour
{
    private SpriteRenderer spriteRend;

    private void Start()
    {
        //StartCoroutine(OnStart);
    }

    private IEnumerator OnStart()
    {
        global::BossBehavour bossBehavour = GetComponent<global::BossBehavour>();
        //BossBehavour.spriteRend.enabled = false;
        yield return new WaitForSeconds(15);
        //BossBehavour.spriteRend.enabled = true;
    }
    }
       
    


