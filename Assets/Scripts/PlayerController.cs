using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;
    Animator anim;

    [SerializeField]
    float speed;

    public bool canMove;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canMove = false;
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.velocity = new Vector2(-speed, 0);
                transform.localScale = new Vector3(-5, 5, 5);
                anim.Play("run-Animation");
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.velocity = new Vector2(speed, 0);
                transform.localScale = new Vector3(5, 5, 5);
                anim.Play("run-Animation");
            }
            else
            {
                rb2d.velocity = Vector2.zero;
                anim.Play("PlayerIdle");
            }
        }
    }
}
