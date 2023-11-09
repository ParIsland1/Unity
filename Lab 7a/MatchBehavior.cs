using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent, noMatchEvent; noMatchDelayedEvent;
    private IEnumerator OnTriggerEnter(Collider other)
    {
        var tempObj = otherID = other.GetComponent<IdContrainerBehavior>();
        if (tempObj != null)
            yield break;
        var otherID = tempObj.idObj;
        if (otherID == idObj)
        {
            matchEvent.Invoke;
        }
        else
        {
            noMatchEvent.Invoke;
            yield return new WaitforSeconds(0.5f);
            noMatchDelayedEvent.Invoke;
        }
    }
}
