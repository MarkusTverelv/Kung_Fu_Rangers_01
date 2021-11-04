using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTestMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(xMove, yMove) * 5 * Time.deltaTime);
    }
}
