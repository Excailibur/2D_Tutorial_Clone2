using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PowerUpType
{
    Bullet_Increase,
    Bullet_FireRate,
    Life_Regen
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType; //Power up type

    public float speed = 5;

    public GameObject playerObject; //Player object

    private Player player;          //Player Script

    public GameObject [] bullet;

    private void Awake()
    {
        playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
    }

    private void Update()
    {
        transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enter");
            ApplyPowerUp(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUp(GameObject player)
    {
        switch (powerUpType)
        {
            case PowerUpType.Bullet_Increase:
                Apply_Bullet_Increase();
                break;
            case PowerUpType.Bullet_FireRate:
                Apply_Bullet_FireRate();
                break;
            case PowerUpType.Life_Regen:
                
                break;
            default:
                Debug.LogWarning("Unknown power-up type: " + powerUpType.ToString());
                break;
        }
    }

    private void Apply_Bullet_Increase()
    {
        if (player.getBulletCount() == 1)
        {
            player.setBullet(bullet[0]);
        }
        else if (player.getBulletCount() == 2)
        {
            player.setBullet(bullet[1]);
        }

        
    }

    private void Apply_Bullet_FireRate()
    {
        player.setFireRate(3f);
    }
}