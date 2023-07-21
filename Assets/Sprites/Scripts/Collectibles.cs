using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public bool speed, health;
    public int speedBoost, healthBoost, duration;
    private float baseMoveSpeed;
    public Player_Movement player;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (speed)
        {
            player.moveSpeed += speedBoost;
            StartCoroutine(BackToBaseSpeed());
        }

        if (health)
        {
            player.healthpoints += healthBoost;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        baseMoveSpeed = player.moveSpeed;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BackToBaseSpeed()
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed = baseMoveSpeed;
    }
}
