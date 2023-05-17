using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    private Transform weaponTransform;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform weaponSpriteTransform;

    private void Awake()
    {
        weaponTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = GetMousePosition();
        Vector3 aimDirection = (mousePosition - weaponTransform.position).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        weaponTransform.eulerAngles = new Vector3(0f, 0f, aimAngle);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, weaponSpriteTransform.position, weaponSpriteTransform.rotation);
        }

    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        return mousePosition;
    }

}
