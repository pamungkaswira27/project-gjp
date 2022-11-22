using UnityEngine;

public class HealthStation : MonoBehaviour
{
    [SerializeField] int healthRegenerate;
    [SerializeField] Transform detector;
    [SerializeField] float detectorRadius;
    [SerializeField] LayerMask playerLayer;

    PlayerMortality playerMortality;

    void Awake()
    {
        playerMortality = FindObjectOfType<PlayerMortality>();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(detector.position, detectorRadius, playerLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Regenarate
                playerMortality.IncreaseHealth(healthRegenerate);
                Debug.Log("Health Increase");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detector.position, detectorRadius);
    }
}
