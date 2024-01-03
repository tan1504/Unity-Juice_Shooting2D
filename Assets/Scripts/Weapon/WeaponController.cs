using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector2 mousePosition;
    public GameObject crosshair;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        RotateCannon();     
    }

    private void FixedUpdate()
    {
        //RotateCannon();       
    }

    void ProcessInputs()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.position = new Vector2(mousePosition.x, mousePosition.y);
        crosshair.transform.Rotate(new Vector3(0, 0, 0.1f));
    }

    void RotateCannon()
    {
        Vector2 aimDirection = mousePosition - (Vector2)transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 180f;

        Quaternion rotation = Quaternion.Euler(0, 0, aimAngle);
        transform.rotation = rotation;
    }
}
