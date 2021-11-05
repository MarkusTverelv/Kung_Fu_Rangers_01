using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGFX : MonoBehaviour
{
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
            sr.flipX = true;
        else
            sr.flipX = false;
    }
}
