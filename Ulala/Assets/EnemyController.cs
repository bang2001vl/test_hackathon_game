using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Speed;
    public float DistanceStopping;
    public float DistanceRetreat;
    public Transform Player;
    public int Health;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Vector2.Distance(Player.position,transform.position)>DistanceStopping)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }
    }
    public void Damage()
    {
        Health -= BulletController.Damage;
        if (Health<=0)
        {
            Destroy(gameObject);
        }
    }
}
