using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [HideInInspector]
    public Vector2 aimDirection;

    public GameObject laser;

    public float timer;
    public float fireRate;

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePos - transform.position;

        LookAtTarget(aimDirection);

        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer >= fireRate)
            Shoot();

    }
    private void LookAtTarget(Vector2 dir)
    {
        float lookAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, lookAngle);
    }

    private void Shoot()
    {
        aimDirection.Normalize();

        Instantiate(laser, transform.position, Quaternion.identity);

        timer = 0.0f;
    }
}
