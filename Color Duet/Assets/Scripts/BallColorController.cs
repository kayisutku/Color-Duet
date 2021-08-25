using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorController : MonoBehaviour
{
    [SerializeField] float colorChangeHeight = 0.8f;
    Color ownColor;
    Color lerpColor;
    [SerializeField] Color mixColor;

    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        //renderer.material.SetColor("_Color", mixColor);
        ownColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y)  < colorChangeHeight)
        {
            renderer.material.SetColor("_Color", Color.Lerp(ownColor , mixColor, (colorChangeHeight - Mathf.Abs(transform.position.y) / colorChangeHeight    )));
        } 
    }

    
}
