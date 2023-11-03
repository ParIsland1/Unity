using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent onEvent1;
    public UnityEvent onEvent2;
    public UnityEvent onEvent3;

    public void TriggerEvent1()
    {
        onEvent1.Invoke();
    }

    public void TriggerEvent2()
    {
        onEvent2.Invoke();
    }

    public void TriggerEvent3()
    {
        onEvent3.Invoke();
    }
}
