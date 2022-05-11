using System;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public int timeoutDestroy = 5;
    public GameObject bullet;
    public GameObject barrelEnd;
    public float bulletSpeed = 10f;
    public Transform gun;
    public float firerate = 10f;
    public float lastfired;
    public GameObject trap;

    private void Update()
    {
        ShootBullet();
        PlacePrefab();

    }

    void ShootBullet()
    {
        //when mouse is held down, shoot a bullet from barrelEnd with a velocity of 10 in the direction of the mouse every 2 seconds
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastfired > 1 / firerate)
            {
                lastfired = Time.time;
                var bulletInstance = Instantiate(bullet, barrelEnd.transform.position, barrelEnd.transform.rotation);
                bulletInstance.GetComponent<Rigidbody>().velocity = bulletInstance.transform.forward * bulletSpeed;
                Destroy(bulletInstance, timeoutDestroy);
            }
            // //when mouse is clicked, shoot a bullet from barrelEnd with a velocity of 10 in the direction of the barrelEnd
            // if (Input.GetMouseButtonDown(0))
            // {
            //     GameObject bulletClone = Instantiate(bullet, barrelEnd.transform.position, barrelEnd.transform.rotation);
            //     bulletClone.GetComponent<Rigidbody>().velocity = bulletClone.transform.forward * bulletSpeed;
            //     Destroy(bulletClone, timeoutDestroy);
        }
    }

    void PlacePrefab()
    {
        //when the mouse is clicked, place a prefab at the mouse position
        if (Input.GetKeyDown("1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(trap, hit.point, Quaternion.identity);
            }
        }
    }
}