using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    //Point value of the enemy
    [SerializeField] private int point_value = 10;

    [SerializeField] GameObject[] powerups;

    void Update()
    {
        transform.position -= new Vector3 (0, speed, 0)*Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Laser"))
        {
            Game_Manager.instance.IncreaseScore(point_value);
            Destroy(collision.gameObject);
            //Spawn Power Up
            SpawnPowerUP();
            Destroy(gameObject);
        }
    }

    private void SpawnPowerUP()
    {
        int random_Powerup = Random.Range(0, powerups.Length);
        int rate = Random.Range(0, 100);
        if (rate <= 50)
        {
            Instantiate(powerups[random_Powerup], transform.position, Quaternion.identity);
        }
    }
}
