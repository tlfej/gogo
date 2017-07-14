using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//캐릭터 상태 enum변수
[System.Serializable]
public class Anim
{
    public AnimationClip wait;
    public AnimationClip walk;
    public AnimationClip attack;
    public AnimationClip damage;
    public AnimationClip dead;
}


public class ChaterCtrl : MonoBehaviour {
    private Transform tr;
    private Rigidbody rbody;

    public float movespeed = 2.0f;
    public float rotspeed= 100f;

    private GameObject ca;
    public Anim anim;
    public Animation _animation;

    


    Vector3 movedir;

	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        rbody = GetComponent<Rigidbody>();
        _animation = GetComponent<Animation>();
        _animation.clip = anim.wait;
        _animation.Play();
        ca = GameObject.Find("Main Camera");
        
	}
	
	// Update is called once per frame
	void Update () {
        movedir = (tr.forward *Input.GetAxis("Vertical") ) + (tr.right * Input.GetAxis("Horizontal")).normalized;
        //movedir = (Vector3.forward * Input.GetAxis("Vertical")) + (Vector3.right * Input.GetAxis("Horizontal") );
        tr.Rotate(Vector3.up * Time.deltaTime * rotspeed * Input.GetAxis("Horizontal"));
        

        rbody.velocity = movedir * movespeed;
		if( Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical")!= 0)
        {
           
            ca.transform.LookAt(tr.position);
            _animation.CrossFade(anim.walk.name, 0.3f);

        }
        else if (Input.GetMouseButtonDown(0))
        {
            _animation.CrossFade(anim.attack.name, 0.3f);
        }
        else
        {
            _animation.CrossFade(anim.wait.name, 0.3f);
        }
       
	}
}
