using System.Collections;
using UnityEngine;

public class RangeEventHandler : MonoBehaviour
{
    public delegate void CloseRangeEventHandler();
    public CloseRangeEventHandler CloseRange;
    public delegate void OutOfRangeEventHandler();
    public OutOfRangeEventHandler OutOfRange;

    [SerializeField] private readonly float _range;

    private RangeState _currentState;
    [SerializeField] private RangeState[] _rangeStates;

    private void Update()
    {
        /*if (InRange(Player.Instance.transform.position, _range))
        {
            if (CloseRange != null) CloseRange();
        }

        if (!InRange(Player.Instance.transform.position, _range))
        {
            if (OutOfRange != null) OutOfRange();
        }*/
    }

    private IEnumerator StateMachine()
    {
        _currentState.StateEnter();

        while (_currentState.Reason())
        {
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
