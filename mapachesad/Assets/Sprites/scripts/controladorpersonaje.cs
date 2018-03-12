using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorpersonaje : MonoBehaviour {
    public float jump =100f;
    private Animator animator;
    private bool suelo = true;
    public Transform comsalto;
    private float radio = 0.07f;
    public LayerMask mascaraSuelo;
    private bool dobleSalto = false;
   
    public float separacion =3f;
    public float speed = 15.0f;
    

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
   void FixedUpdate()
    {
        suelo = Physics2D.OverlapCircle(comsalto.position, radio, mascaraSuelo);
        animator.SetBool("isground",suelo);
        if (suelo)
        {
            dobleSalto = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.RightArrow))
        {
            
            transform.position += Vector3.right * speed * Time.deltaTime;
            animator.SetBool("iswalk", true);
        }
           else 
        {
            animator.SetBool("iswalk", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime ;
            animator.SetBool("iswalk", true);
            flip();
            
        }
        else
        {
            animator.SetBool("iswalk", false);
            
        }

        if ((suelo||!dobleSalto) && Input.GetKeyUp(KeyCode.UpArrow))
        {
          
            transform.position += Vector3.up*jump * Time.deltaTime;
            
            if (!dobleSalto && !suelo)
            {
                dobleSalto = true;
            }
        }

       
    }
    void flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
    
}
