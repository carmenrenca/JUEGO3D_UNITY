using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaTerceraPersona : MonoBehaviour
{

  public Transform puntoDeDisparo;
     public float daño= 20f;
    public float velocidadMovimiento= 5.0f;
    public float valocidadRotacion= 200.0f;
    private Animator anim;
    public float x,y;

    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x=Input.GetAxis("Horizontal");
        y=Input.GetAxis("Vertical");

      transform.Rotate(0,x*Time.deltaTime*valocidadRotacion,0);
      transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);
      anim.SetFloat("VelX",x);
      anim.SetFloat("VelY",y);

      if(Input.GetKey("a")){
          ReproducirAnimacionDisparo();
                      


      }
    }

    
    void DisparoDirecto(){
        RaycastHit hit;
        if(Physics.Raycast(puntoDeDisparo.position, puntoDeDisparo.forward, out hit)){
            if(hit.transform.CompareTag("Enemigo")){
            Vida vida = hit.transform.GetComponent<Vida>();
            if(vida==null){
                throw new System.Exception("No se encontro el componente vida del enemigo");

            }else{
                vida.recibirdaño(daño);
                
            }
            }
        }
    }

      public virtual void ReproducirAnimacionDisparo(){
   
           
                anim.CrossFadeInFixedTime("mixamo_com",0.5f);
      
    }
    }

