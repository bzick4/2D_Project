
using UnityEngine;

public class MoveTimeline : MonoBehaviour
{
    [SerializeField] Transform targetPoint;
    [SerializeField] private float speed = 0.7f;

    private bool isMoving = false;

    void Update()
    {
        
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)targetPoint.position, speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, targetPoint.position) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
    
    public void StartMoving()
    {
        isMoving = true;
    }
}

