using UnityEngine;
using UnityEngine.Events;

public class RangeEvent : MonoBehaviour {

    public UnityEvent closeRangeEvent;
    public UnityEvent outOfRangeEvent;
    [SerializeField] private GameObject[] _listeners;
    [SerializeField] private string[] _listenersWithTag;

    private void Awake()
    {
        // Get listeners
        for (int i = 0; i < _listeners.Length; i++)
        {
            _listeners[i].GetComponent<RangeEventHandler>().CloseRange += OnCloseRange;
            _listeners[i].GetComponent<RangeEventHandler>().OutOfRange += OnOutOfRange;
        }

        // Get listeners by tag
        for (int i = 0; i < _listenersWithTag.Length; i++)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(_listenersWithTag[i]);
            for (int j = 0; j < objects.Length; j++)
            {
                objects[j].GetComponent<RangeEventHandler>().CloseRange += OnCloseRange;
                objects[j].GetComponent<RangeEventHandler>().OutOfRange += OnOutOfRange;
            }
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

