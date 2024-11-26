
using UnityEngine;

public class MoveTimeline : MonoBehaviour
{
    [SerializeField] Vector3 targetPosition;
    [SerializeField] private float speed = 0.7f;

    private bool isMoving = false;

    void Update()
    {
        
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * -Time.deltaTime);
            
            if (transform.position == targetPosition)
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

