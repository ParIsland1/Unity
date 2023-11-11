using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent;

    private void OnTriggerEnter(Collider other)
    {
        var tempObj = other.GetComponent<IDContainerBehavior>();

        if (tempObj == null)
        {
            // Handle the case where the other collider doesn't have an IDContainerBehavior
            return;
        }

        var otherID = tempObj.idObj;

        if (otherID == idObj)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchDelayedEvent.Invoke();
            StartCoroutine(NoMatchDelayedLogic());
        }
    }

    private IEnumerator NoMatchDelayedLogic()
    {
        yield return new WaitForSeconds(0.5f);
        noMatchDelayedEvent.Invoke();
    }
}

