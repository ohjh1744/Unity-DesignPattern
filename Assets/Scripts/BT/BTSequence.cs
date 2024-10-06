using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ù ������ Ȯ��, �����ϸ� �ٷ� failure return, ���а� ������ �ϳ��� Running�� ������ Running �ƴ϶�� Success ����.
public class BTSequence : BTNode
{
    public override BTNodeState Evaluate()
    {
        bool isAnyCHildRunning = false;
        foreach(BTNode node in children)
        {
            BTNodeState result = node.Evaluate();
            if(result == BTNodeState.Failure)
            {
                return BTNodeState.Failure;
            }
            else if(result == BTNodeState.Running)
            {
                isAnyCHildRunning = true;
            }
        }

        return isAnyCHildRunning ? BTNodeState.Running : BTNodeState.Success;
    }
}
