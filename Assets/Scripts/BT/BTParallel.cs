using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTParallel : BTNode
{
    public override BTNodeState Evaluate()
    {
        bool isAnyRunning = false;
        bool isAllSuccess = true;

        foreach (BTNode node in children)
        {
            BTNodeState result = node.Evaluate();
            if (result == BTNodeState.Running)
            {
                isAnyRunning = true;
            }
            else if (result == BTNodeState.Failure)
            {
                isAllSuccess = false;
            }
        }

        return isAnyRunning ? BTNodeState.Running : (isAllSuccess ? BTNodeState.Success : BTNodeState.Failure);
    }
}
