using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Y Position of the player
    private float yPosition;

    [SerializeField] private int Player_Health = 3;

    //Laser for player
    [SerializeField] private GameObject laser;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float MaxRate = 10f;
    private int bulletCount = 1;

    void Start()
    {
        //Make Sure Player Health stays at 3
        Player_Health = 3;
        //Locks the Y
        yPosition = transform.position.y;

        InvokeRepeating("Shoot", 0, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(position.x, yPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
            Damage();
        }
    }

    private void Shoot()
    {
        Instantiate(laser, transform.position, Quaternion.identity);
    }

    public void setBullet(GameObject newBullet)
    {
        laser = newBullet;
        bulletCount++;
    }

    public void setFireRate(float newFireRate)
    {
        if (fireRate < MaxRate)
        {
            fireRate += newFireRate;
        }
    }

    public int getBulletCount()
    {
        return bulletCount;
    }

    public void Damage()
    {
        Debug.Log(Player_Health);
        Player_Health--;
        Game_Manager.instance.TakeDamage(Player_Health);
        if(Player_Health == 0)
        {
            Game_Manager.instance.GameOver();
            Destroy(gameObject);
        }
    }
}
