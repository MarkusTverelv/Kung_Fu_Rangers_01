using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTVCamera : MonoBehaviour
{
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LookAtTarget(Vector2 dir)
    {
        float lookAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, lookAngle - 90);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LookAtTarget(targetTransform.position - transform.position);
        }
    }
}
