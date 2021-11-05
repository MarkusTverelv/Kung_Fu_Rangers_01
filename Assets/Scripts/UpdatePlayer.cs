using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayer : MonoBehaviour
{
    public BoxCollider2D coll2D;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = coll2D.bounds;
        player.groundHeight = bounds.max.y;
    }
}
