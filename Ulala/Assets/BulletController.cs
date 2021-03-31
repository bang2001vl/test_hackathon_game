using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Enemy, Player
}
public class BulletController : MonoBehaviour
{
    public static int Damage = 5;
    public int Speed;
    private Vector3 _direction;
    private BulletType _type;
    public BulletController() { }
    public void Init(Vector3 direction, Vector3 position, BulletType type)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        _direction = direction;
        _type = type;
        transform.position = position;
    }
    private void Update()
    {
        transform.position += _direction.normalized * Speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().Damage();
            Destroy(gameObject);
        }
    }

}
