using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    public static Transform player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (player == null) player = Player.instance.transform;
    }

    private void Update()
    {
        Vector3 lookPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookPosition);
    }

    private void FixedUpdate()
    {
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
}
