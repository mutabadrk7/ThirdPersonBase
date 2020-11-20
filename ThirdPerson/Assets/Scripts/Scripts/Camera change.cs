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
        if (!aimCamera.activeInHierarchy)
        { 
        mainCamara.SetActive(false);
            aimCamera.SetActive(true);

            StartCoroutine(ShowReticle());
        }
        else if(true)
        {
            mainCamara.SetActive(true);
            aimCamera.SetActive(false);
            aimReticle.SetActive(false);

        }
    }
}
