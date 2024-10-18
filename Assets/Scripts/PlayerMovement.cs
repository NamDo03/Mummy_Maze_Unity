using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public float moveDuration = 0.5f;
    public float moveDistance = 1f;

    private bool isMoving;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateIdleDirection();
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
                StartCoroutine(Move(Vector3.up * moveDistance));       
            else if (Input.GetKeyDown(KeyCode.S))
                StartCoroutine(Move(Vector3.down * moveDistance));     
            else if (Input.GetKeyDown(KeyCode.A))
                StartCoroutine(Move(Vector3.left * moveDistance));     
            else if (Input.GetKeyDown(KeyCode.D))
                StartCoroutine(Move(Vector3.right * moveDistance ));
        }
    }

    public IEnumerator Move(Vector3 direction)
    {
        isMoving = true;

        animator.SetBool("isMoving", true);

        if (direction == Vector3.up * moveDistance)
        {
            animator.SetInteger("moveDirection", 1); 
        }
        else if (direction == Vector3.down * moveDistance)
        {
            animator.SetInteger("moveDirection", 2); 
        }
        else if (direction == Vector3.left * moveDistance) 
        {
            animator.SetInteger("moveDirection", 3); 
        }
        else if (direction == Vector3.right * moveDistance )
        {
            animator.SetInteger("moveDirection", 4); 
        }

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + direction;

        float elapsed = 0;


        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        animator.SetBool("isMoving", false);
        isMoving = false;
    }
    private void UpdateIdleDirection()
    {
        float horizontal = 0;
        float vertical = 0;

        if (Input.GetKey(KeyCode.W))
            vertical = 1; 
        else if (Input.GetKey(KeyCode.S))
            vertical = -1; 

        if (Input.GetKey(KeyCode.A))
            horizontal = -1; 
        else if (Input.GetKey(KeyCode.D))
            horizontal = 1;

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("idleDirectionX", horizontal);
            animator.SetFloat("idleDirectionY", vertical);
        }
    }
}
