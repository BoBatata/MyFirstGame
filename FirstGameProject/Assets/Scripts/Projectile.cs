using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float bulletVelocity;
    [SerializeField] private float bulletLifeTime = 1f;

    private void Start()
    {
        StartCoroutine(LifeSpan());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * bulletVelocity * Time.deltaTime);
    }

    private IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(gameObject);
    }
}
