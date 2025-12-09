using System;
using System.Collections;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] GameObject deathCardParent;
    [SerializeField] GameObject highPriestessParent;
    
    public bool deathCardActive = false;
    public bool highPriestessActive =  false;
    private bool isRevealing = false;
    
    public void TriggerDeathCardReveal()
    {
        if (!isRevealing)
        {
            StartCoroutine(ShowDeathCard());
        }
    }

    public void TriggerHighPriestessReveal()
    {
        if (!isRevealing)
        {
            StartCoroutine(ShowHighPriestess());
        }
    }
    

    public IEnumerator ShowDeathCard()
    {
        isRevealing = true;
        Time.timeScale = 0f;
        deathCardParent.SetActive(true);

        Animator animator = deathCardParent.GetComponent<Animator>();
        animator.Update(0f);
        animator.Play("CardReveal",  -1, 0f);
        
        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animLength);

        deathCardParent.SetActive(false);
        Time.timeScale = 1f;
        isRevealing = false;
    }

    public IEnumerator ShowHighPriestess()
    {
        isRevealing = true;
        Time.timeScale = 0f;
        highPriestessParent.SetActive(true);

        Animator animator = highPriestessParent.GetComponent<Animator>();
        animator.Update(0f);
        animator.Play("CardReveal",  -1, 0f);
        
        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animLength);
        
        highPriestessParent.SetActive(false);
        Time.timeScale = 1f;
        isRevealing = false;
    }
}
