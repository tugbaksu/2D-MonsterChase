using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 8.5f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG="Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //A ve D harfi veya ok tuþlarýnda sað sol ile x eks. konumunu deðiþtirir
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer()
    {
        //we'r going to the right side (d or right arrow keys)
        if (movementX>0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }

        //we'r going to the left side (a or left arrow keys)
        else if (movementX<0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            //The character will try to go left,
            //which means he normally faces right, but when he heads left he will turn left.
            sr.flipX = true;
        }
        //we'r not going to any side (standing)
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
             
        
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }
    }

}
