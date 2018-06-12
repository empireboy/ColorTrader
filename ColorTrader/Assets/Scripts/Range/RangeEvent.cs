using UnityEngine;
using UnityEngine.Events;

public class RangeEvent : MonoBehaviour {

    public UnityEvent closeRangeEvent;
    public UnityEvent outOfRangeEvent;
    [SerializeField] private GameObject[] _listenerGameObjectArray;

    private void Awake()
    {
        for (int i = 0; i < _listenerGameObjectArray.Length; i++)
        {
            _listenerGameObjectArray[i].GetComponent<RangeEventHandler>().CloseRange += OnCloseRange;
            _listenerGameObjectArray[i].GetComponent<RangeEventHandler>().OutOfRange += OnOutOfRange;
        }
    }

    public void OnCloseRange()
    {
        closeRangeEvent.Invoke();
    }

    public void OnOutOfRange()
    {
        outOfRangeEvent.Invoke();
    }
}
