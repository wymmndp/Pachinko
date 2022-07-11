using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int moveSpeed = 7;
    private int direction = 1;
    private string statePlayer = "PLAY";
    private Rigidbody2D playerRB2D = null;
    // Start is called before the first frame update
    void Start()
    {
        playerRB2D = GetComponent<Rigidbody2D>();
        playerRB2D.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if(statePlayer == "PLAY")
        {
            if (transform.position.x >= 8) direction = -1;
            if (transform.position.x <= -8) direction = 1;
            transform.position += Vector3.right * Time.deltaTime * moveSpeed * direction;
        }
        if(Input.GetMouseButtonDown(0) && statePlayer == "PLAY")
        {
            statePlayer = "FALLING DOWN";
            playerRB2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            statePlayer = "PLAY";
            GameManager.instance.GetPoint();
            Respawn();
        }
        if(collision.gameObject.tag == "Death")
        {
            statePlayer = "PLAY";
            Respawn();
        }
    }

    private void Respawn()
    {
        playerRB2D.bodyType = RigidbodyType2D.Kinematic;
        gameObject.transform.SetPositionAndRotation(new Vector3(0, 4.2f, 0), Quaternion.identity);
    }
}
