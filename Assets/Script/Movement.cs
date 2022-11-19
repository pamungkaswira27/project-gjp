using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
       [Header("MOVEMENT")] 
       public float moveSpeed;
       public float jumpForce;
       private Rigidbody2D myRb;
       
       public bool isFacingRight;
       
       public bool isJumping;
       
       [Space] 
       
       [Header("GROUND CHEKER")]
       public float radius;
       public Transform groundChecker;
       public LayerMask whatIsGround;
   
       
       
       
       private void Awake()
       {
           myRb = GetComponent<Rigidbody2D>();
   
       }
   
       private void FixedUpdate()
       {
           MovementPlayer();
       }
       void Start()
       {
           
       }
   
       void Update()
       {
           Jump();
       }
       void MovementPlayer()
       {
           float move = Input.GetAxisRaw("Horizontal");
           myRb.velocity = new Vector2(move * moveSpeed, myRb.velocity.y);
   
           if (move > 0 && !isFacingRight)
           {
               transform.eulerAngles = Vector2.zero;
               isFacingRight = true;
   
           }
           else if(move < 0 && isFacingRight)
           {
               transform.eulerAngles = Vector2.up * 180;
               isFacingRight = false;
           }
       }
   
       void Jump() 
       {
           if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
           {
               myRb.velocity = Vector2.up * jumpForce;
           }
   
           if (!IsGrounded() && !isJumping)
           {
               isJumping = true;
           }
           else if (IsGrounded() && isJumping)
           {
               isJumping = false;
           }
       }
   
       bool IsGrounded()
       {
           return Physics2D.OverlapCircle(groundChecker.position, radius, whatIsGround);
       }
   
       private void OnDrawGizmos()
       {
           Gizmos.DrawWireSphere(groundChecker.position,radius);
       }
}
