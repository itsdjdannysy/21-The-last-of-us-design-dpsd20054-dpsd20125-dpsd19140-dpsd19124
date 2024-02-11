using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public GameObject UI;

    // Update is called once per frame
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x + 1)
        {
            Application.Quit();
        }
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
