using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerAimWeapon : MonoBehaviour
{
    Transform aimTransform;
    private void Awake()
    {
        aimTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (aimTransform == null) return;
        Vector3 mouseposition = Input.mousePosition;
        Vector3 aimdirection = (mouseposition - transform.position).normalized;
        var angle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);
    }
}
