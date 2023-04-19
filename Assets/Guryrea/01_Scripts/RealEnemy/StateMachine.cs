using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    //기본 상태를 생성시에 설정하게 생성자 만들기.
    public StateMachine(IState defaultState)
    {
        CurrentState = defaultState;
    }

    //외부에서 현재상태를 바꿔주는 부분.
    public void SetState(IState state)
    {
        if (CurrentState == state)
            return;

        //상태가 바뀌기 전에, 이전 상태의 Exit를 호출한다.
        CurrentState.OnStateExit();

        //상태 교체.
        CurrentState = state;

        //새 상태의 Enter를 호출한다.
        CurrentState.OnStateEnter();
    }

    //매프레임마다 호출되는 함수.
    public void DoOperateUpdate()
    {
        CurrentState.OnStateUpdate();
    }
}
