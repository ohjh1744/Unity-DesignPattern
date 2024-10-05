using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BTCondition : BTNode
{
    private Func<bool> condition;

    public  BTCondition(Func<bool> condition)
    {
        this.condition = condition;
    }

    public override BTNodeState Evaluate()
    {
        return condition() ? BTNodeState.Success : BTNodeState.Failure;
    }
}
