using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public Transform player;
    public float dist = 5f;
    public float height = 2f;
    public float rotspeed = 5.0f;

    float radi = 0;
    Vector3 movedir;
    Vector3 mousepo;
    private Transform tr;
    Vector3 mouseim;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
      
	}
   
    // Update is called once per frame
    void LateUpdate () {
        tr.position = Vector3.Lerp(tr.position, player.position - (player.forward * dist) + Vector3.up * height, Time.deltaTime * 20.0f);

        /*

        if (Input.GetMouseButtonDown(0))
        {
            mouseim = Input.mousePosition;
          
        }
        if (Input.GetMouseButton(0))
        {
            mousepo = Input.mousePosition;
            if (mouseim.x < mousepo.x)
            {
                if (radi > 360) radi = 0;
                radi += 10f;

                mouseim = mousepo;

            }
            else if (mouseim.x > mousepo.x)
            {
                if (radi < -1*360) radi = 0;
                radi += -1 * 10f;               
                 mouseim = mousepo;
            }
            movedir = (player.transform.forward * Mathf.Sign(radi) + player.transform.right * Mathf.Cos(radi)).normalized * dist;
        }

        tr.position = Vector3.Lerp(tr.position, (player.position +movedir+ Vector3.up * height), Time.deltaTime * 20.0f);



        */

        //if (Input.GetMouseButtonDown(0))
        //{
        //    mouseim = Input.mousePosition;
        //    Debug.Log(Input.mousePosition);
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    mousepo = Input.mousePosition;
        //    if (mouseim.x < mousepo.x)
        //    {
        //        radi = 10f;
        //        tr.transform.RotateAround(player.transform.position, Vector3.up, radi);
        //        //Debug.Log(radi);
        //        // tr.Rotate(player.transform.up * radi*Time.deltaTime);
        //        // tr.rotation = Quaternion.Euler(tr.up * radi * Time.deltaTime);
        //        // mouseim = mousepo;

        //    }
        //    else if (mouseim.x > mousepo.x)
        //    {
        //        radi = -1 * 10f;
        //        tr.transform.RotateAround(player.transform.position, Vector3.up, radi);
        //        //Debug.Log(radi);
        //        // tr.Rotate(Vector3.up * radi * Time.deltaTime );
        //        //tr.rotation = Quaternion.Euler(tr.up * radi * Time.deltaTime);
        //        // mouseim = mousepo;
        //    }

        //     }


        //    //// movedir = (.forward * Mathf.Sign(radi) + Vector3.right * Mathf.Cos(radi)).normalized * dist;
        //    // if (Input.GetMouseButtonDown(0))
        //    // {
        //    //     mouseim = Input.mousePosition;
        //    //     Debug.Log(Input.mousePosition);
        //    // }
        //    // if (Input.GetMouseButton(0))
        //    // {
        //    //     mousepo = Input.mousePosition;
        //    //     if(mouseim.x < mousepo.x)
        //    //     {
        //    //         radi = 20f;
        //    //         //Debug.Log(radi);
        //    //         // tr.Rotate(player.transform.up * radi*Time.deltaTime);
        //    //         tr.rotation = Quaternion.Euler(tr.up * radi * Time.deltaTime );
        //    //         mouseim = mousepo;

        //    //     }
        //    //     else if(mouseim.x >mousepo.x)
        //    //     {
        //    //         radi = -1*20f;
        //    //         //Debug.Log(radi);
        //    //         // tr.Rotate(Vector3.up * radi * Time.deltaTime );
        //    //         tr.rotation = Quaternion.Euler(tr.up * radi * Time.deltaTime );
        //    //         mouseim = mousepo;
        //    //     }

        //    // }

        //    // /*
        //    // if (Input.GetMouseButton(0))
        //    // {
        //    //     Debug.Log("눌려있당");
        //    // }*/

        //     tr.position = Vector3.Lerp(tr.position,(player.position - player.transform.forward*dist +Vector3.up *height),Time.deltaTime*20.0f) ;

    }
}
