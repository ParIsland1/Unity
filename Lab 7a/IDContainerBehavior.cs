using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IdContrainerBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEventQueueSystem startEvent;

    public void Start()
    {
        startEvent.Invoke();
    }
}
