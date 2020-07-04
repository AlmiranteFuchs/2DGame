using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("MovementVars")]
    public Rigidbody2D pRb;
    [Header("CrossHair")]
    public GameObject crossHair;
    [Header("Character")]
    public Character character;
    PlayerControllerInputs playerCntrlInputs;

    //Charstuff
    private Animator anim;
    private SpriteRenderer sprites;

    void Start()
    {
        pRb= SystemReferences.instance.playerRef.transform.GetComponent<Rigidbody2D>();
        playerCntrlInputs= GetComponent<PlayerControllerInputs>();
        sprites=this.GetComponent<SpriteRenderer>();
        updateFromChar();
    }

    void Update()
    {
        
    }

    public void PMove(){
        pRb.velocity= playerCntrlInputs.pmovementDirection *playerCntrlInputs.pmovementSpeed*10;

        /* anim.SetFloat("Horizontal", playerCntrlInputs.pmovementDirection.x);
        anim.SetFloat("Vertical", playerCntrlInputs.pmovementDirection.y);
        if ((playerCntrlInputs.pmovementDirection.x != 0) || (playerCntrlInputs.pmovementDirection.y != 0))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if ((playerCntrlInputs.pmovementDirection.x != 0) || (playerCntrlInputs.pmovementDirection.y != 0))
        {
            anim.SetBool("isShooting", true);
        }else{
            anim.SetBool("isShooting", false);
        } */
    }

    public void PAim(Vector2 _mousePosition, Vector2 _pshootDirection){
       /*  crossHair.transform.position = _mousePosition;
        SystemReferences.instance.handHolder.transform.right=_pshootDirection; */
    }

    void updateFromChar(){
        //anim.runtimeAnimatorController= character.cAnimator;
        sprites.sprite= character.cSprite;
    }
}
