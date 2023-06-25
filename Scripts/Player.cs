using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Moveforce=10f;

    [SerializeField]
    private float jumpforce=11f;

    private float movementX;
    private string GROUND_TAG="Ground";

    private string Enemy_Tag="Enemy";
    private Rigidbody2D myBody;

    private Animator anim;
    private SpriteRenderer sr;
private bool isGround;
    private string WALK_ANIMATION="Walk";


    private void Awake(){
        myBody=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PLayerMoveKeyBoard();
        AnimatePlayer();
        
    }
    void FixedUpdate(){
        PlayerJump();
    }
    void PLayerMoveKeyBoard(){
        movementX=Input.GetAxisRaw("Horizontal");
        transform.position+=new Vector3(movementX,0f,0f)*Time.deltaTime*Moveforce;
    }
    void AnimatePlayer(){
      

      if (movementX>0)
      {
        //We are going to the right side
         anim.SetBool(WALK_ANIMATION,true);
         sr.flipX=false;
      }
      else if(movementX<0){
         //we are going to the left side
        anim.SetBool(WALK_ANIMATION,true);
        sr.flipX=true;
      }
      else{
        anim.SetBool(WALK_ANIMATION,false   );
      }
    }
    void PlayerJump(){
        if(Input.GetButtonDown("Jump")&& isGround){
            isGround=false;
           myBody.AddForce(new Vector3(0f,jumpforce),ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
       if (collision.gameObject.CompareTag(GROUND_TAG))
       {
         isGround=true;
       }
       if (collision.gameObject.CompareTag(Enemy_Tag)){
         Destroy(gameObject);
       } 

    }

    private void OnTriggerEnter2D(Collider2D collision){

      if (collision.gameObject.CompareTag(Enemy_Tag))
      {
        Destroy(gameObject);
      }
    }
}