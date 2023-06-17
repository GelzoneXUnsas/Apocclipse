using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Spawner spawner;

    public float speed;

    private float curPosX;

    private float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        curPosX = spawner.transform.position.x;
        rotSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        speed -= 0.05f * Time.deltaTime;
        curPosX += speed * Time.deltaTime;
        transform.position =
            new Vector3(curPosX, spawner.transform.position.y, 0f);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);

        if (gameObject != null && gameObject.CompareTag("Obstacle"))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.0f);

            // Make the object spin around the y-axis
            transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
            rotSpeed += 0.1f * Time.deltaTime;
        }
        if (gameObject != null && gameObject.CompareTag("Collect"))
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.0f);

            // Make the object spin around the y-axis
            transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
            rotSpeed += 0.03f * Time.deltaTime;
        }
    }
}
