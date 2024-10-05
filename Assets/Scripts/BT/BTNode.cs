using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BTNodeState
{
    Success,
    Failure,
    Running
}
public abstract class BTNode : MonoBehaviour
{
    protected List<BTNode> children = new List<BTNode>();

    public void AddChild(BTNode node)
    {
        children.Add(node);
    }

    public abstract BTNodeState Evaluate();
}

