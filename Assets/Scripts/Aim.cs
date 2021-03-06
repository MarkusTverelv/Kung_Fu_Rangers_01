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

    private AudioSource audioSource;
    public AudioClip laserSFX;

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(laserSFX);

        timer = 0.0f;
    }
}
