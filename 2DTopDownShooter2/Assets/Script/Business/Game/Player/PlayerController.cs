using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;

    public float moveSpeed;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Animator playerAnimator;
    public bool isWalking;

    private Vector2 moveDirection;

    private Vector2 mousePosition;


    private void Start()
    {
        playerAnimator = transform.Find("PlayerSprite").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProccesInputs();
    }

     void FixedUpdate()
    {
        Move();

        //Physics Calculation
    }

    void ProccesInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Check if the player is walking
        isWalking = (Mathf.Abs(moveX) > 0.1f || Mathf.Abs(moveY) > 0.1f);

        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }


        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        //Update the "isWalking" parameter in the Animator
        playerAnimator.SetBool("isWalking", isWalking);

    }

  
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //Rotate player to follow mouse

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

    }
}
