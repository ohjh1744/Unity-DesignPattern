using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFactory : MonsterFactory
{
    public override Monster Create()
    {
        return Instantiate(new Orc());
    }

}
