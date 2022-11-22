using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed;

    public bool isTurnOn = false;

    Vector3 targetPos;

    int waypointIndex = 0;
    bool moveForward = true;

    void Update()
    {
        if (isTurnOn)
        {
            FollowPath();
        }
    }

    void FollowPath()
    {
        if (moveForward)
        {
            MovePlatform();

            if (transform.position == targetPos)
            {
                if (waypointIndex != waypoints.Length - 1)
                    waypointIndex++;
                else
                    moveForward = false;
            }
        }
        else if (!moveForward)
        {
            MovePlatform();

            if (transform.position == targetPos)
            {
                if (waypointIndex > 0)
                    waypointIndex--;
                else
                    moveForward = true;
            }
        }
    }

    void MovePlatform()
    {
        targetPos = waypoints[waypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }

    public void TurnOnPlatform()
    {
        if (!isTurnOn)
            isTurnOn = true;
        else
            isTurnOn = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.parent = this.transform;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }
}
