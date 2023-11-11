using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(Text))]
public class TextLabelBehavior : MonoBehaviour
{
    public TMP_Text label;
    public UnityEvent startEvent;
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<TMP_Text>();
        startEvent.Invoke();
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
