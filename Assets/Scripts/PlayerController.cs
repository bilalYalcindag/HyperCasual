using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 100;
    private CurrentDirection currentDirection;
    private bool isPlayerDead = false;
    private GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentDirection = CurrentDirection.right;
        gameManager = FindObjectOfType<GameManager>();
        
    }

    
    void Update()
    {   
        if(!isPlayerDead)
        {
            RaycastDetector();
            if (Input.GetKeyDown("space"))  //Input.touchCount > 0 && Input.GetTouch(0).phase ==TouchPhase.Began
            {
                ChangeDirection();
                PlayerStop();
            }
            else
            {
                return;
            }
         }
        
        
    }
 private enum CurrentDirection
    {
        right,left
    }

private void ChangeDirection()
    {
        MovePlayer();
        if (currentDirection == CurrentDirection.right)
        {
            currentDirection = CurrentDirection.left;
        }       
        else if (currentDirection == CurrentDirection.left)
        {
            currentDirection = CurrentDirection.right;
        }
      
    }

    private void RaycastDetector()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            MovePlayer();
        }
        else
        {
            PlayerStop();
            isPlayerDead = true;
            this.gameObject.SetActive(false);
            gameManager.LevelEnd();

        }
    }
  
    private void MovePlayer()
    {
        if (currentDirection== CurrentDirection.right)
        {
            rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
            
        }
        else if (currentDirection == CurrentDirection.left)
        {
            rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void PlayerStop()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finishTrigger"))
        {
            gameObject.SetActive(false);
            gameManager.NextLevel();
         
        }
    }


}
