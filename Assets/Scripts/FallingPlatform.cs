using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float timeToFall;

    void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(PlatformFallingCoroutine());
    }

    IEnumerator PlatformFallingCoroutine()
    {
        yield return new WaitForSeconds(timeToFall);
        Debug.Log("Fall");
        transform.LeanMoveLocalY(-Screen.height, 150f);
        Destroy(gameObject);
    }
}
