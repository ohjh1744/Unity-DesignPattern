using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BTAction : BTNode
{

    public BTAction( )
    {

    }

    public override abstract BTNodeState Evaluate();

}
