using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] MovingPlatform movingPlatform;
    [SerializeField] Transform detector;
    [SerializeField] float detectorRadius;
    [SerializeField] LayerMask playerLayer;

    void Update()
    {
        if (Physics2D.OverlapCircle(detector.position, detectorRadius, playerLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                movingPlatform.TurnOnPlatform();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detector.position, detectorRadius);
    }
}
