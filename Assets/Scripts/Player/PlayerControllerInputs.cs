using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerControllerInputs : MonoBehaviour
{
    public Vector2 pmovementDirection, pshootingDirection, pmousePosition;
    public float pmovementSpeed;

    void Update()
    {
        ProcessMoveInputs();
        ProcessShootInputs();
        ProcessCommandsInputs();

    }

    private void ProcessCommandsInputs()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SystemReferences.instance.playerRef.GetComponent<PlayerInteracter>().Interact();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SystemReferences.instance.UIinventory.gameObject.SetActive(!SystemReferences.instance.UIinventory.gameObject.activeSelf);
        }
    }

    void ProcessMoveInputs()
    {
        pmovementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        pmovementSpeed = Mathf.Clamp(pmovementDirection.magnitude, 0.0f, 1.0f);
        pmovementDirection.Normalize();
        this.transform.GetComponent<PlayerController>().PMove();
    }
    void ProcessShootInputs()
    {
        //Takes the mouse position and stuff
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        pmousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 tempDir = pmousePosition;
        pshootingDirection = tempDir - this.transform.position;
        this.transform.GetComponent<PlayerController>().PAim(pmousePosition, pshootingDirection);

        //Animation stuff
        if (pshootingDirection.x < 0f)
        {
            //SystemReferences.instance.weaponSlot.GetComponent<SpriteRenderer>().flipY = true;
            //Need to flip the Y on the Tip Once
            //GetComponent<GunsController>().UpdateTip(true);
            //SystemReferences.instance.shootRotation.transform.position= SystemReferences.instance.lHand.transform.position;

        }
        else
        {
            //SystemReferences.instance.weaponSlot.GetComponent<SpriteRenderer>().flipY = false;
            //GetComponent<GunsController>().UpdateTip(false);
            //SystemReferences.instance.shootRotation.transform.position= SystemReferences.instance.rHand.transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            //GetComponent<GunsController>().ShootGun(pshootingDirection.x, pshootingDirection.y);
            //Debug.Log(GetComponent<CharacterStats>().damage);
        }
    }
}
