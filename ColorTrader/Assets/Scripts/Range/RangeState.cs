using UnityEngine;

public abstract class RangeState : MonoBehaviour
{
    public virtual void StateEnter() { }
    public abstract bool Reason();
}