using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mCircleScript : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private GameObject gameControl;
    void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("gameControllerTag");
    }

    // Update is called once per frame
    void Update()
    {
        bulletAction();
    }

    private void bulletAction ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            gameControl.GetComponent<gameControlScript>().updateBulletCounting();

        }
    }

    
}
