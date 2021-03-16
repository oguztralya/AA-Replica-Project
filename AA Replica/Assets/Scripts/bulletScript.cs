using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private Rigidbody2D r_Rigidbody;
    [SerializeField] private float b_speed=0;
    private bool movementCheck = true;
    private GameObject gameControlCon;
    void Start()
    {
        r_Rigidbody = GetComponent<Rigidbody2D>();
        gameControlCon = GameObject.FindGameObjectWithTag("gameControllerTag");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementCheck)
        {
            r_Rigidbody.MovePosition(r_Rigidbody.position + Vector2.up * Time.deltaTime * b_speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rCircleTag")
        {
            movementCheck = false;
            transform.SetParent(collision.transform);

        }
        if(collision.gameObject.tag=="bulletTag")
        {
            Debug.Log("Game Over");
            gameControlCon.GetComponent<gameControlScript>().GameOver();

        }
    }
}
