using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") )
        {
            animator.SetBool("isDust", true);
            StartCoroutine(PlayDustAndWhiteFight());
        }
    }

    public void ABC()
    {
        animator.SetBool("isDust", true);
        StartCoroutine(PlayDustAndWhiteFight());
    }

    private IEnumerator PlayDustAndWhiteFight()
    {
        yield return new WaitForSeconds(1.0f);  
        animator.SetBool("isDust", false);
        animator.SetBool("isFight", true);            
    }
}

