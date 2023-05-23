using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{

    [SerializeField] private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LifeSpan());
        Transform playerLocation = PlayerScript.instance.GetPlayerTransform();
        if (transform.position.x - playerLocation.position.x < 0)
        {
            velocity = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
