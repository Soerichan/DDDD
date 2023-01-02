using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController m_controller;
    private Animator m_animator;

    [SerializeField]
    private float m_fMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        m_controller = GetComponent<CharacterController>(); 
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate();
    }

    public void Move(Vector2 InputDir)
    {
        Vector2 moveInput = InputDir;

        bool isMove = moveInput.sqrMagnitude != 0;

        if(true==isMove)
        {

            Vector3 fowardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
            Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;
            Vector3 moveVec = fowardVec * moveInput.y + rightVec * moveInput.x;
            m_controller.Move(moveVec * m_fMoveSpeed * Time.deltaTime);
            transform.forward = moveVec.normalized;
            m_animator.SetBool("Move", true);
        }
        else
        {
            m_animator.SetBool("Move", false);
        }
    }

    private void Rotate()
    {
        
    }
}
