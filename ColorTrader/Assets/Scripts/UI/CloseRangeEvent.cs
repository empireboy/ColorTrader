using UnityEngine;

public class CloseRangeEvent : MonoBehaviour {

    [SerializeField] private Behaviour _component;
    [SerializeField] private GameObject[] _listenerGameObjectArray;

    private void Awake()
    {
        for (int i = 0; i < _listenerGameObjectArray.Length; i++)
        {
            _listenerGameObjectArray[i].GetComponent<TraderEventHandler>().CloseRange += OnCloseRange;
        }
    }

    public void OnCloseRange()
    {
        _component.enabled = true;
    }
}
