using UnityEngine;

public class CloseRangeState : RangeState
{
    [SerializeField] private readonly float _range;

    public override bool Reason()
    {
        if (RangeController.IsInRange(gameObject.transform.position, Player.Instance.transform.position, _range))
        {
            //DomovoiStateMachine.Instance.ChangeState(DomovoiStateMachine._eStates.KillPlayer);
            return false;
        }
        return true;
    }
}
