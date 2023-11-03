using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public EventManager eventManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            eventManager.TriggerEvent1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            eventManager.TriggerEvent2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            eventManager.TriggerEvent3();
        }
    }
}
