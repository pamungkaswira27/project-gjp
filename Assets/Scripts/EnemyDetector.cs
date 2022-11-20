using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] Transform playChecker;
    [SerializeField] float playChekerRadius;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] EnemyMovement enemyMovement;

    [HideInInspector] public bool isPlayerDetected {get; private set;}

    void Update()
    {
        if (IsPlayerDetected())
        {
            enemyMovement.SetMovementSpeed(0f);
            isPlayerDetected = true;
        }
        else if (!IsPlayerDetected())
        {
            enemyMovement.RestoreMovement();
            isPlayerDetected = false;
        }
    }

    bool IsPlayerDetected()
    {
        return Physics2D.OverlapCircle(playChecker.position, playChekerRadius, playerLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playChecker.position, playChekerRadius);
    }
}
