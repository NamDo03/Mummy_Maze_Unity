using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour
{
    private Animator animator;
    private GameObject playerInstance;
    private bool isCollidingWithMummy = false;
    public bool isTargetForDestroy = false;
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
        if (collision.CompareTag("Mummy") && !isCollidingWithMummy)
        {
            isCollidingWithMummy = true;

            MummyController otherMummyController = collision.GetComponent<MummyController>();

            if (isTargetForDestroy)
            {
                StartCoroutine(PlayDustAndDestroy(gameObject));
            }
            else
            {
                StartCoroutine(PlayDustAndSurvive());
            }

            if (otherMummyController.isTargetForDestroy)
            {
                StartCoroutine(PlayDustAndDestroy(collision.gameObject));
            }
            else
            {
                otherMummyController.StartCoroutine(otherMummyController.PlayDustAndSurvive());
            }
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
    private IEnumerator PlayDustAndSurvive()
    {
        animator.SetBool("isDust", true);

        yield return new WaitForSeconds(1.0f);

        animator.SetBool("isDust", false);
        isCollidingWithMummy = false;
    }

    private IEnumerator PlayDustAndDestroy(GameObject mummyToDestroy)
    {
        Animator destroyAnimator = mummyToDestroy.GetComponent<Animator>();
        destroyAnimator.SetBool("isDust", true);

        yield return new WaitForSeconds(1.0f);

        Destroy(mummyToDestroy);
    }
}

