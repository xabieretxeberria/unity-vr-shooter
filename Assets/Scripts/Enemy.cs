using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    public static Transform player;

    private const float PLAYER_REACHED_DISTANCE = 1.6f;
    private static bool playerReached = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (player == null) player = Player.instance.transform;
    }

    private void Update()
    {
        Vector3 lookPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookPosition);

        if (PlayerReached()) {
            playerReached = true;
        }
    }

    private void FixedUpdate()
    {
        if (playerReached) {
            Stop();
            GameController.instance.GameFailed();
            return;
        }

        rb.velocity = transform.forward * speed;
    }

    public void Destroy()
    {
        ScoreManager.instance.AddDestroyedEnemy();
        Recycle();
    }

    private void Recycle()
    {
        gameObject.SetActive(false);
    }

    private bool PlayerReached()
    {
        return Vector3.Distance(transform.position, player.position) < PLAYER_REACHED_DISTANCE;
    }

    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
