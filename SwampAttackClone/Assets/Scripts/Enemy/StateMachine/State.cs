using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] 
    private List<Transition> _transitions;

    protected Player Target { get; set; }

    public void Enter(Player target)
    {
        if(!enabled)
        {
            Target = target;
            enabled = true;
            foreach(var t in _transitions)
            {
                t.enabled = true;
                t.Init(target);
            }
        }
    }

    public State GetNextState()
    {
        foreach(var t in _transitions)
        {
            if(t.NeedTransit)
            {
                t.ResetNeedTransit();
                return t.TargetState;
            }
        }
        return null;
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var t in _transitions)
            {
                t.enabled = false;
            }
            enabled = false;
        }
    }
}
