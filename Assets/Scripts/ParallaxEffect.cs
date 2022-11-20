using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Header("Parallax Effect")]
    [SerializeField] Vector2 parallaxEffectMultiplier;
    [SerializeField] bool infiniteHorizontal;
    [SerializeField] bool infiniteVertical;

    Sprite sprite;
    Texture2D texture;
    Transform camTransform;

    Vector3 lastCamPosition;

    float textureUnitSizeX;
    float textureUnitSizeY;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Start()
    {
        camTransform = Camera.main.transform;
        lastCamPosition = camTransform.position;

        texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = camTransform.position - lastCamPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCamPosition = camTransform.position;

        if (infiniteHorizontal)
        {
            if (Mathf.Abs(camTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetX = (camTransform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(camTransform.position.x + offsetX, transform.position.y);
            }
        }

        if (infiniteVertical)
        {
            if (Mathf.Abs(camTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetY = (camTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, camTransform.position.y + offsetY);
            }
        }
    }
}
