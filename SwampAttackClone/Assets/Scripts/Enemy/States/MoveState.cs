using UnityEngine;

public class MoveState : State
{
    [SerializeField] 
    private float _speed;

    private void FixedUpdate()
    {
        if (!Target)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * _speed);
    }
}
