using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class GardeController : MonoBehaviour
{
    private CharacterController gc;
    private float speed = 100;
    public Vector3 moveDir;
    public float direction;
    private bool rotate = false;
    private Vector3 fieldOfView;
    private Vector3 player;
    public bool isHidden = true;

    public Transform character;

    // Start is called before the first frame update
    void Start()
    {
        gc = GetComponent<CharacterController>();
        StartCoroutine(DoWalk());
    }

    // Update is called once per frame
    private void Update()
    {
        fieldOfView= transform.TransformDirection(Vector3.forward);
        player = character.position - transform.position;
        if(Vector3.Dot(player,fieldOfView) > 0)
        {
            isHidden= false;
        }
        else
        {
            isHidden= true;
        }
    }

    private IEnumerator DoWalk()
    {
        while (true)
        {

            if(!rotate) {
                direction = UnityEngine.Random.Range(0.1f, 359.9f);
                transform.eulerAngles = new Vector2(0, direction);
                yield return new WaitForSecondsRealtime(3);
                rotate= true;
            }
            if(rotate) {
                transform.DOMove(transform.position + transform.forward*10, 3f).SetEase(Ease.InSine);
                yield return new WaitForSecondsRealtime(3);
                rotate = false;
            }
            
        }
 
    }
}
