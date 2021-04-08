using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    private GameObject[] players;

    Vector2 movement;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();
        players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 1)
        {
            Destroy(players[1]);
        }
    }

    void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }
}

//BodziixWasHere    >o)
//                  (_)>