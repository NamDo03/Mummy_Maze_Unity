using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private PlayerStats playerStats;
    public float moveDuration = 0.5f;
    public float moveDistance = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();
        GameObject cameraObject = Camera.main.gameObject;  
        if (cameraObject != null)
        {
            playerStats = cameraObject.GetComponent<PlayerStats>(); 
        }

        if (playerStats == null)
        {
            Debug.LogError("PlayerStats not found on the Camera! Ensure PlayerStats script is attached to the Camera.");
        }
    }

    void Update()
    {

    }
    
    public IEnumerator Move(Vector3 direction, bool isBlocked)

    {
        if (isBlocked) yield break;
        direction *= moveDistance;
        animator.SetBool("isMoving", true);

        playerStats.AddStep();

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
    }
    public void Fighting()
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

    public void UpdateIdleDirection(Vector3? next_move = null)
    {
        float horizontal = 0;
        float vertical = 0;
        if (next_move.HasValue)
        {
            
            if (next_move == Vector3.up)
                vertical = 1;
            else if (next_move == Vector3.down)
                vertical = -1;

            if (next_move == Vector3.left)
                horizontal = -1;
            else if (next_move == Vector3.right)
                horizontal = 1;
        } else
        {
            if (Input.GetKey(KeyCode.W))
                vertical = 1;
            else if (Input.GetKey(KeyCode.S))
                vertical = -1;

            if (Input.GetKey(KeyCode.A))
                horizontal = -1;
            else if (Input.GetKey(KeyCode.D))
                horizontal = 1;
        }

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("idleDirectionX", horizontal);
            animator.SetFloat("idleDirectionY", vertical);
        }
    }
}
