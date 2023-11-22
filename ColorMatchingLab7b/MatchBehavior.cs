using UnityEngine.Events;
using UnityEngine;
using System.Collections;

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

            // Destroy the game object when there is a match
            Destroy(other.gameObject);
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
