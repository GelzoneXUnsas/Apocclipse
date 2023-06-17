using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public float speed;

    public bool isMoving;

    public GameObject staticBackground;

    public float cameraX;

    public float farBackgroundSpeed;

    public PlayerController player;

    public Dialogue dialog;
    private static bool hasRestarted = false;

    public float distance;

    // Use this for initialization
    void Start()
    {
        cameraX = transform.position.x;
        isMoving = false;
        farBackgroundSpeed = 0.03f;
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.curHealth <= 0)
        {
            isMoving = false;
            hasRestarted = true;
        }
        if ((Input.GetKey(KeyCode.Space) && !dialog.isDialogue) || hasRestarted)
        {
            isMoving = true;
        }

        /*        if (transform.position.x >= 6.0f)
        {
            transform.Translate(new Vector3(-28f, 0, 0));
        }*/
        if (isMoving)
        {
            staticBackground
                .transform
                .Translate(new Vector3(-speed *
                    Time.deltaTime *
                    farBackgroundSpeed,
                    0,
                    0));
            distance += 1 * Time.deltaTime;
        }
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     Debug.Log(cameraX);
        // }
        // cameraX = transform.position.x;
    }
}
