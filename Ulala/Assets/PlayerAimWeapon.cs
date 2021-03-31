using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerAimWeapon : MonoBehaviour
{
    Transform aimTransform;
    public GameObject Bullet;
    public int Health;
    private void Start()
    {
        
    }
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        AimMouse();
        ClickEvent();
    }
    private void AimMouse()
    {

        Vector3 aimdirection = AimDirection();
        float angle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
    private void ClickEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.Shot();
        }
    }

    private void Shot()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.GetComponent<BulletController>().Init(AimDirection(),transform.position,BulletType.Player);
        Destroy(bullet, 3f);
    }

    private Vector3 AimDirection()
    {
        Vector3 mouseposition = Input.mousePosition;
        Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        return mouseposition - screenpoint;
    }
}
