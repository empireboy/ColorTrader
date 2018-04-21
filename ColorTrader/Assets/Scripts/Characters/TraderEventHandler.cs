using UnityEngine;

public class TraderEventHandler : MonoBehaviour {

    public delegate void CloseRangeEventHandler();
    public CloseRangeEventHandler CloseRange;

    [SerializeField] private float _range;

    private void Update()
    {
        if (InRange(Player.Instance.transform.position, _range)) {
            if (CloseRange != null) CloseRange();
        }
    }

    private bool InRange(Vector3 target, float range)
    {
        if (Vector3.Distance(transform.position, target) <= range) return true;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
