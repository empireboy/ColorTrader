using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CloseRangeState))]
[RequireComponent(typeof(OutOfRangeState))]
public class RangeEventHandler : MonoBehaviour
{
    public delegate void CloseRangeEventHandler();
    public CloseRangeEventHandler CloseRange;
    public delegate void OutOfRangeEventHandler();
    public OutOfRangeEventHandler OutOfRange;

    public enum RangeStates { CloseRange, OutOfRange }

    [SerializeField] private RangeState _currentState;
    private RangeState _closeRangeState;
    private RangeState _outOfRangeState;

    private void Start()
    {
        _closeRangeState = gameObject.GetComponent<CloseRangeState>();
        _outOfRangeState = gameObject.GetComponent<OutOfRangeState>();

        _currentState = _closeRangeState;

        ChangeState(RangeStates.CloseRange);
    }

    private IEnumerator StateMachine()
    {
        _currentState.StateEnter();

        while (_currentState.Reason())
        {
            yield return null;
        }
    }

    public void ChangeState(RangeStates newState)
    {
        switch (newState)
        {
            case RangeStates.CloseRange:
                _currentState = _closeRangeState;
                break;
            case RangeStates.OutOfRange:
                _currentState = _outOfRangeState;
                break;
        }
        StartCoroutine(StateMachine());
    }

    private void OnDrawGizmos()
    {
        if (_currentState != _outOfRangeState)
        {
            Gizmos.color = Color.blue;
        }
        else Gizmos.color = Color.black;

        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y + 4, transform.position.z), 0.5f);
    }
}
