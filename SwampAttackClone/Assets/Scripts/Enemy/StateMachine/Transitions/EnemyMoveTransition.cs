using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTransition : Transition
{
    public void StartMoving()
    {
        NeedTransit = true;
    }
}
