using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class BTAction : BTNode
{
    private Func<BTNodeState> action;
    public BTAction(Func<BTNodeState>action )
    {
        this.action = action;
    }

    public override  BTNodeState Evaluate()
    {
        return action();
    }

}
