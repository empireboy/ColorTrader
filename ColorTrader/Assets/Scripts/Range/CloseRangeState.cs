using UnityEngine;

[RequireComponent(typeof(RangeEventHandler))]
public class CloseRangeState : RangeState
{
    [SerializeField] private float _range;

    private RangeEventHandler _rangeEventHandler;

    private void Start()
    {
        _rangeEventHandler = gameObject.GetComponent<RangeEventHandler>();
    }

    public override void StateEnter()
    {
        _rangeEventHandler.CloseRange();
    }

    public override bool Reason()
    {
        if (!RangeController.IsInRange(gameObject.transform.position, Player.Instance.transform.position, _range))
        {
            gameObject.GetComponent<RangeEventHandler>().ChangeState(RangeEventHandler.RangeStates.OutOfRange);
            return false;
        }
        return true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
