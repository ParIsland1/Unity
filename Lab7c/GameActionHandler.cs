using UnityEngine;
using UnityEngine.EVents 

public class GameActionHandler : MonoBehavior 
{
    public GameAction gameActionObj;
    public UnityEvent onRaiseEvent; 

    private void Start()
    {
        gameActionObj.raise += Raise; 
    }

    private void Raise()
    {
        onRaiseEvent.Invoke();
    }
}