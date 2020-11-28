using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camerachange : MonoBehaviour
{
    public PlayerController input;

    public GameObject mainCamara;
    public GameObject aimCamera;
    public GameObject aimReticle;


        // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Aim") && !aimCamera.activeInHierarchy)
        { 
             mainCamara.SetActive(false);
            aimCamera.SetActive(true);

            StartCoroutine(ShowReticle());
        }
        else if(!Input.GetButton("Aim") && aimCamera.activeInHierarchy)
        {
            
            mainCamara.SetActive(true);
            aimCamera.SetActive(false);
            aimReticle.SetActive(false);

        }
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    IEnumerable ShowReticle()
    {
        yield return new WaitForSeconds(0.25f);
        aimReticle.SetActive(true);
    }
}
