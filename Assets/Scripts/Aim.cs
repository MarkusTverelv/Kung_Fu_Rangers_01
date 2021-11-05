using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [HideInInspector]
    public Vector2 aimDirection;

    public GameObject laser;
    public Transform firePoint;

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
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer >= fireRate)
            Shoot();
    }

    private void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = mousePos - transform.position;

        aimDirection.Normalize();

        Instantiate(laser, firePoint.position, Quaternion.identity);

        timer = 0.0f;
    }
}
