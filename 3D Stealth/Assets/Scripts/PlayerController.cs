using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    public float speed;
    public Vector3 moveDir;
    public Camera currentCam;
    private Vector2 yBounds = new Vector2(10, 50);
    float camDistance = 10, currentX, currentY;
    float cameraSensi = 25f;

    // Start is called before the first frame update
    private void Start()
    {
        moveDir = transform.position;
        cc = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        DoCharacterMove();
        DoCameraMove();
        RaycastHit hit;
        Vector3 startingPoint = transform.position + (transform.forward* 0.5f);
        if (Physics.Raycast(startingPoint, transform.forward,out hit,.5f)) 
        {
            if(hit.transform.tag == "Guard" && hit.transform.GetComponent<GardeController>().isHidden && Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Destroy(hit.transform.gameObject);
                UIController.Instance.OnVictory();
            }
        }
    }

    private void DoCharacterMove()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 mouvement = currentCam.transform.right*horizontal+currentCam.transform.forward*vertical;
        mouvement.y = 0;
        cc.Move(mouvement);

        if (mouvement.magnitude != 0)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * cameraSensi * Time.deltaTime);
            Quaternion camRot = currentCam.transform.rotation;
            camRot.x = 0;
            camRot.z = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation,camRot,0.2f);
        }
    }

    private void DoCameraMove()
    {
        
        currentX += Input.GetAxis("Mouse X") * cameraSensi * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * cameraSensi * Time.deltaTime;
        currentY = Math.Clamp(currentY,yBounds.x,yBounds.y);
        

        Vector3 direction = new Vector3(0, 0, -camDistance);
        Quaternion rotation = Quaternion.Euler(currentY,currentX,0);
        currentCam.transform.position = transform.position + rotation* direction;
        currentCam.transform.LookAt(transform.position);
    }
}
