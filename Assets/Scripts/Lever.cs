using UnityEngine;
using UnityEngine.UI;

public class Lever : MonoBehaviour
{
    [SerializeField] MovingPlatform movingPlatform;
    [SerializeField] Sprite[] switchImage;
    [SerializeField] Transform detector;
    [SerializeField] float detectorRadius;
    [SerializeField] LayerMask playerLayer;

    SpriteRenderer spriteRenderer;
    int index = 1;

    void Awake()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(detector.position, detectorRadius, playerLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                movingPlatform.TurnOnPlatform();
                spriteRenderer.sprite = switchImage[index];

                index++;
                if (index >= switchImage.Length)
                {
                    index = 0;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detector.position, detectorRadius);
    }
}
