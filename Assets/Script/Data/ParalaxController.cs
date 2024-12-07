using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [SerializeField] private Transform _Followingtarget;
    [SerializeField, Range(0f, 1f)] private float _ParallaxStrenght = 0.1f;
    private bool isDisablVerticalParallax=false;
    private Vector3 _targetPreviousPosition;

    private void Start()
    {
        if (!_Followingtarget)
        {
            _Followingtarget = Camera.main.transform;
        }
        _targetPreviousPosition = _Followingtarget.position;
    }

    private void Update()
    {
        var delta = _Followingtarget.position - _targetPreviousPosition;
        if (isDisablVerticalParallax)
        {
            delta.y = 0;
        }
        _targetPreviousPosition = _Followingtarget.position;
        transform.position += delta * _ParallaxStrenght;
    }
}
