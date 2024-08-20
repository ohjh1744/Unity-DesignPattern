using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Monster
{
    public override void Attack()
    {
        Debug.Log("좀비 공격!");
    }
    
}
