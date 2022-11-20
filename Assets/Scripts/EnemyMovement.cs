using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool isFacingRight;

    // Checker
    [SerializeField] Transform groundChecker;
    [SerializeField] float groundChekerRadius;
    [SerializeField] LayerMask whatIsGround;

    float savedMoveSpeed;

    void Start()
    {
        savedMoveSpeed = moveSpeed;
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        
        if (!ThereIsGround())
        { 
            if (isFacingRight)
            {
                transform.eulerAngles = Vector2.up * 180;
                isFacingRight = false;
            }
            else
            {
                transform.eulerAngles = Vector2.zero;
                isFacingRight = true; 
            }
        }
    }

    bool ThereIsGround()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundChekerRadius, whatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position,groundChekerRadius);
    }

    public bool IsFacingRight()
    {
        return isFacingRight;
    }

    public void SetMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void RestoreMovement()
    {
        moveSpeed = savedMoveSpeed;
    }
}
