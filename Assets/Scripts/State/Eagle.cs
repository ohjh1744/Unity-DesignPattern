using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Eagle : MonoBehaviour
{
    
    public enum State { Idle,  Trace, Return, Attack, Dead, Size}
    [SerializeField] State curState = State.Idle;
    private BaseState[] states = new BaseState[(int)State.Size];

    [SerializeField] GameObject player;
    [SerializeField] float traceRange;
    [SerializeField] float attackRange;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 startPos;

    [SerializeField] Text stateText;

    private void Awake()
    {
        states[(int)State.Idle] = new IdleState(this);
        states[(int)State.Trace] = new TraceState(this);
        states[(int)State.Return] = new ReturnState(this);
        states[(int)State.Attack] = new AttackState(this);
        states[(int)State.Dead] = new DeadState(this);
    }
    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        states[(int)curState].Enter();
    }

    
    void Update()
    {
        states[(int)curState].Update();
        stateText.text = curState.ToString();
    }

    private void OnDestroy()
    {
        states[(int)curState].Exit();
    }

    public void ChangeState(State state)
    {
        states[(int)curState].Exit();
        curState = state;
        states[(int)curState].Enter();
    }

    private class EagleState: BaseState
    {
        public Eagle eagle;

        public EagleState(Eagle eagle)
        {
            this.eagle = eagle;
        }
    }

    private class IdleState: EagleState
    {
        private float timer;

        public IdleState(Eagle eagle) : base(eagle){

        }
        public override void Enter()
        {
            timer = 0f;
        }

        public override void Update()
        {
            timer += Time.deltaTime; 
        }

        public override void Exit()
        {
           
        }
    }

    private class TraceState: EagleState
    {
        public TraceState(Eagle eagle) : base(eagle)
        {

        }
    }

    private class  ReturnState : EagleState
    {
        public ReturnState(Eagle eagle) : base(eagle)
        {

        }
    }

    private class  AttackState: EagleState
    {
        public AttackState(Eagle eagle) : base(eagle)
        {

        }
    }

    private class DeadState: EagleState
    {
        public DeadState(Eagle eagle) : base(eagle)
        {

        }
    }
}
