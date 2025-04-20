using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 

    private Vector3 moveDirection;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 

        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 targetPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
            transform.position = targetPosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("ExitTile"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.EndGame();
            }
        }
    }

}
