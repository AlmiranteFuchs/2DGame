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
            SystemReferences.instance.playerRef.transform.Find("InteractRadius").GetComponent<PlayerInteracter>().Interact();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SystemReferences.instance.UIinventory.transform.GetChild(0).gameObject.SetActive(!SystemReferences.instance.UIinventory.transform.GetChild(0).gameObject.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < this.gameObject.GetComponent<PlayerEquipmentManager>().currentEquipments.Length; i++)
            {
                this.gameObject.GetComponent<PlayerEquipmentManager>().UnEquip(i);
            }
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<SkillController>().UseSkill(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<SkillController>().UseSkill(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<SkillController>().UseSkill(2);
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
        if (Input.GetMouseButtonDown(0))
        {
            //Attack
            Debug.Log(this.gameObject.GetComponent<PlayerStats>().attackDmg);
        }
        if (Input.GetMouseButtonDown(1))
        {
            //Nada por enquanto
        }
    }
}
