using UnityEngine;

[RequireComponent(typeof(RangeEventHandler))]
public class OutOfRangeState : RangeState
{
    [SerializeField] private float _range;

    private RangeEventHandler _rangeEventHandler;

    private void Start()
    {
        _rangeEventHandler = gameObject.GetComponent<RangeEventHandler>();
    }

    public override void StateEnter()
    {
        if (_rangeEventHandler.OutOfRange != null) _rangeEventHandler.OutOfRange();
    }

    public override bool Reason()
    {
        if (RangeController.IsInRange(gameObject.transform.position, Player.Instance.transform.position, _range))
        {
            gameObject.GetComponent<RangeEventHandler>().ChangeState(RangeEventHandler.RangeStates.CloseRange);
            return false;
        }
        return true;
    }
}
