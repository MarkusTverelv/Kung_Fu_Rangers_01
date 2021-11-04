using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    public bool hasSetValue;
    public float depth = 1;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float resetX; 

    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void FixedUpdate()
    {
        
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;
        if (hasSetValue)
        {
            if (pos.x <= -16)
                pos.x = 17;
        }
        else
        {
            float numX = Random.Range(minX, maxX);
            float numY = Random.Range(minY, maxY);

            if (pos.x <= resetX)
            {
                pos.x = numX;
                pos.y = numY;
            }
        }
        
        transform.position = pos;
    }
}
