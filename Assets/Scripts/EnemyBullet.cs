using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed, damage, destroyTime;
    // public Rigidbody2D rb;
    EnemyMovement enemyMovement;

    private void Awake()
    {
        enemyMovement = FindObjectOfType<EnemyMovement>();
        Destroy(gameObject,destroyTime);
    }


    void Update()
    {
        if (!enemyMovement.IsFacingRight())
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        else
            transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // col.transform.parent.GetComponent<EnemyMortality>().TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("TakeDamage");
        }
        else if (col.CompareTag("Enviroment"))
        {
            Destroy(gameObject);
        }
    }
}
