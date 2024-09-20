using UnityEngine;
using UnityEngine.UI;

public class EagleWithInspector : MonoBehaviour
{
    public enum State { Idle, Trace, Return, Attack, Dead, Size }

    [Header("State")]
    [SerializeField] State curState = State.Idle;

    private BaseState[] states = new BaseState[(int)State.Size];
    [SerializeField] IdleState idleState;
    [SerializeField] TraceState traceState;
    [SerializeField] ReturnState returnState;
    [SerializeField] AttackState attackState;
    [SerializeField] DeadState deadState;

    [Header("Property")]
    [SerializeField] GameObject player;
    [SerializeField] Vector2 startPos;

    [SerializeField] Text stateText;

    private void Awake()
    {
        states[(int)State.Idle] = idleState;
        states[(int)State.Trace] = traceState;
        states[(int)State.Return] = returnState;
        states[(int)State.Attack] = attackState;
        states[(int)State.Dead] = deadState;
    }

    private void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        states[(int)curState].Enter();
    }

    private void OnDestroy()
    {
        states[(int)curState].Exit();
    }

    private void Update()
    {
        states[(int)curState].Update();

        stateText.text = curState.ToString();
    }

    public void ChangeState(State nextState)
    {
        states[(int)curState].Exit();
        curState = nextState;
        states[(int)curState].Enter();
    }

    [System.Serializable]
    private class IdleState : BaseState
    {
        [SerializeField] EagleWithInspector eagle;
        [SerializeField] float traceRange;

        public override void Update()
        {
            // Idle �ൿ�� ����
            // ������ �ֱ�

            // �ٸ� ���·� ��ȯ
            if (Vector2.Distance(eagle.transform.position, eagle.player.transform.position) < traceRange)
            {
                eagle.ChangeState(State.Trace);
            }
        }
    }

    [System.Serializable]
    private class TraceState : BaseState
    {
        [SerializeField] EagleWithInspector eagle;
        [SerializeField] float traceRange;
        [SerializeField] float attackRange;
        [SerializeField] float moveSpeed;

        public override void Update()
        {
            // Trace �ൿ�� ����
            eagle.transform.position = Vector2.MoveTowards(eagle.transform.position, eagle.player.transform.position, moveSpeed * Time.deltaTime);

            // �ٸ� ���·� ��ȯ
            if (Vector2.Distance(eagle.transform.position, eagle.player.transform.position) > traceRange)
            {
                eagle.ChangeState(State.Return);
            }
            else if (Vector2.Distance(eagle.transform.position, eagle.player.transform.position) < attackRange)
            {
                eagle.ChangeState(State.Attack);
            }
        }
    }

    [System.Serializable]
    private class ReturnState : BaseState
    {
        [SerializeField] EagleWithInspector eagle;
        [SerializeField] float moveSpeed;

        public override void Update()
        {
            // Return �ൿ�� ����
            eagle.transform.position = Vector2.MoveTowards(eagle.transform.position, eagle.startPos, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(eagle.transform.position, eagle.startPos) < 0.01f)
            {
                eagle.ChangeState(State.Idle);
            }
        }
    }

    [System.Serializable]
    private class AttackState : BaseState
    {
        [SerializeField] EagleWithInspector eagle;
        [SerializeField] float attackRange;

        public override void Update()
        {
            // Attack �ൿ�� ����
            Debug.Log("����");

            if (Vector2.Distance(eagle.transform.position, eagle.player.transform.position) > attackRange)
            {
                eagle.ChangeState(State.Trace);
            }
        }
    }

    [System.Serializable]
    private class DeadState : BaseState
    {
        [SerializeField] Eagle eagle;
    }


    #region BaseStatePattern
    /*
    private void Idle()
    {
        // Idle �ൿ�� ����
        // ������ �ֱ�

        // �ٸ� ���·� ��ȯ
        if (Vector2.Distance(transform.position, player.transform.position) < traceRange)
        {
            curState = State.Trace;
        }
    }

    private void Trace()
    {
        // Trace �ൿ�� ����
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        // �ٸ� ���·� ��ȯ
        if (Vector2.Distance(transform.position, player.transform.position) > traceRange)
        {
            curState = State.Return;
        }
        else if (Vector2.Distance(transform.position, player.transform.position) < attackRange)
        {
            curState = State.Attack;
        }
    }

    private void Return()
    {
        // Return �ൿ�� ����
        transform.position = Vector2.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, startPos) < 0.01f)
        {
            curState = State.Idle;
        }
    }

    private void Attack()
    {
        // Attack �ൿ�� ����
        Debug.Log("����");

        if (Vector2.Distance(transform.position, player.transform.position) > attackRange)
        {
            curState = State.Trace;
        }
    }

    private void Dead()
    {
        // Dead �ൿ�� ����
        Debug.Log("����");
    }
    */
    #endregion
}
