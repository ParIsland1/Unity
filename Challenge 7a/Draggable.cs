using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour
{
    private Camera cameraObj;
    private bool draggable;
    private Vector3 position, offset;

    public UnityEvent startDragEvent;
    public UnityEvent endDragEvent;

    void Start()
    {
        cameraObj = Camera.main;
    }

    private void OnMouseDown()
    {
        offset = transform.position - cameraObj.ScreenToWorldPoint(Input.mousePosition);
        StartCoroutine(DragCoroutine());
        startDragEvent.Invoke(); // Invoke startDragEvent when dragging starts
    }

    private IEnumerator DragCoroutine()
    {
        draggable = true;

        while (draggable)
        {
            yield return new WaitForFixedUpdate();
            position = cameraObj.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = position;
        }

        endDragEvent.Invoke(); // Invoke endDragEvent when dragging ends
    }

    private void OnMouseUp()
    {
        draggable = false;
    }
}
