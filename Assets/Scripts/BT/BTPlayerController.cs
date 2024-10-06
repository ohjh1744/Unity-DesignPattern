using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTPlayerController : MonoBehaviour
{
    private BTNode root;

    private bool vMove;

    private bool hMove;

    [SerializeField] private Text moveText;

    [SerializeField] private Text[] attackText;

    private void Start()
    {
        //노드 생성
        root = new BTParallel();
        BTNode MoveSequence = new BTSequence();
        BTNode AttackSelector = new BTSelector();
        BTNode WalkAction = new BTAction(Walk);
        BTNode RunAction = new BTAction(Run);
        BTNode SlashAction = new BTAction(Slash);
        BTNode ThrowAction = new BTAction(Throw);
        BTNode ZoomFireParallel = new BTParallel();
        BTNode ZoomAction = new BTAction(Zoom);
        BTNode FireAction = new BTAction(Fire);

        //노드 연결
        root.AddChild(MoveSequence);
        root.AddChild(AttackSelector);
        MoveSequence.AddChild(WalkAction);
        MoveSequence.AddChild(RunAction);
        AttackSelector.AddChild(SlashAction);
        AttackSelector.AddChild(ThrowAction);
        AttackSelector.AddChild(ZoomFireParallel);
        ZoomFireParallel.AddChild(ZoomAction);
        ZoomFireParallel.AddChild(FireAction);
    }

    private void Update()
    {
        root.Evaluate();
    }

    private BTNodeState Walk()
    {
        vMove = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);
        hMove = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
        if (vMove == true || hMove == true)
        {
            moveText.text = "Walk";
            return BTNodeState.Running;
        }
        else
        {
            moveText.text = "None";
            return BTNodeState.Failure;
        }
    }
    private BTNodeState Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveText.text = "Run";
            return BTNodeState.Running;
        }
        else
        {
            return BTNodeState.Failure;
        }
    }

    private BTNodeState Slash()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            attackText[0].text = "Slash";
            return BTNodeState.Running;
        }
        else
        {
            attackText[0].text = "None";
            return BTNodeState.Failure;
        }
    }

    private BTNodeState Throw()
    {
        if (Input.GetKey(KeyCode.T))
        {
            attackText[0].text = "Throw";
            return BTNodeState.Running;
        }
        else
        {
            attackText[0].text = "None";
            return BTNodeState.Failure;
        }
    }

    private BTNodeState Zoom()
    {
        if (Input.GetMouseButton(1))
        {
            attackText[1].text = "Zoom";
            return BTNodeState.Running;
        }
        else
        {
            attackText[1].text = "None";
            return BTNodeState.Failure;
        }
    }

    private BTNodeState Fire()
    {
        if (Input.GetMouseButton(0))
        {
            attackText[0].text = "Fire";
            return BTNodeState.Running;
        }
        else
        {
            attackText[0].text = "None";
            return BTNodeState.Failure;
        }
    }

}
