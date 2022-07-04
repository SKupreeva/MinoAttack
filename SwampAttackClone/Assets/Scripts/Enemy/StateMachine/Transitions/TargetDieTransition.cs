using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (Target == null)
        {
            NeedTransit = true;
        }
    }
}
