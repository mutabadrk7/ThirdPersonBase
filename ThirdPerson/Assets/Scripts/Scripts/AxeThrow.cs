using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : MonoBehaviour
{

    

    GameObject player;
    GameObject weapon;

   public Transform Axe;

    Vector3 startspot;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        

        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        weapon = GameObject.Find("Axe Model");


        weapon.GetComponent<MeshRenderer>().enabled = false;

        


        startspot = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z-1 );


        
    }

   

    // Update is called once per frame
    void Update()
    {
        Axe.transform.Rotate(Time.deltaTime * 500, 0 ,0);

        if (Vector3.Distance(player.transform.position, transform.position) < 1.5)
        {
            rb.velocity =
            Vector3.MoveTowards(transform.position, startspot*40,Time.deltaTime * 40);
        }
        if (Vector3.Distance(player.transform.position, transform.position) > 15)
        {
            rb.velocity=
             Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z + 7), Time.deltaTime * 40);
        }

        if( Vector3.Distance(player.transform.position,transform.position) <1)
        {
            weapon.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
