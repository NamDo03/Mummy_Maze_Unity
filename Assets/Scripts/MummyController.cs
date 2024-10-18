using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour
{
    private Animator animator;
    private GameObject playerInstance;
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
            playerInstance = collision.gameObject;
            StartCoroutine(PlayDustAndWhiteFight());
        }
    }

    private IEnumerator PlayDustAndWhiteFight()
    {
        if (playerInstance != null)
        {
            Destroy(playerInstance);
        }
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("isDust", false);
        animator.SetBool("isFight", true);
    }

}

