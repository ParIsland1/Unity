using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteBehavior : MonoBehaviour
{
    private SpriteRenderer rendererObj;

    private void Awake()
    {
        rendererObj = GetComponent<SpriteRenderer>();
        
    }

    public void ChangeRendererColor(ColorID obj)
    {
        rendererObj.color = obj.value;
        Debug.Log("Color changed to: " + obj.value);
    }

    public void ChangeRendererColor(ColorIDListData obj)
    {
        rendererObj.color = obj.currentColor.value;
        Debug.Log("Color changed to: " + obj.currentColor.value);
    }
}
