using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyahaha : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float moveSpeed;
    public bool isFacingRight;
    
    //cheker
    public Transform groundChecker;
    public float groundChekerRadius;
    public LayerMask whatIsGround;

    public Transform hudBar;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right *moveSpeed*Time.deltaTime);
        if (!ThereIsGround())
        { 
            if (isFacingRight)
            {
                hudBar.localEulerAngles = Vector2.zero;
                transform.eulerAngles = Vector2.up * 180;
                isFacingRight = false;
            }
            else
            {
                hudBar.localEulerAngles = Vector2.up * 180; ;
                transform.eulerAngles = Vector2.zero;
                isFacingRight = true; 
            }
        }
    }

    bool ThereIsGround()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundChekerRadius, whatIsGround
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position,groundChekerRadius);
    }
}
