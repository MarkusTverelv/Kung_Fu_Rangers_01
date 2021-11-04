using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayer : MonoBehaviour
{
    public BoxCollider2D collider2D;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = collider2D.bounds;
        player.groundHeight = bounds.max.y;

    }
}
