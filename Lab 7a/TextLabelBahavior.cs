using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class TextLabelBehavior : MonoBehaviour
{
    private Text label;
    public UnityEvent startEvent;
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<Text>();
        startEvent.Invoke;
    }

    public void UpdateLabel(FloatData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
}

