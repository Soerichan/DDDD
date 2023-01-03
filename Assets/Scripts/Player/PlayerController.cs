using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState { Idle, Glide, Die }

public class PlayerController : MonoBehaviour
{
    private CharacterController m_controller;
    private Animator m_animator;

    [SerializeField]
    private float m_fMoveDefaultSpeed;

    [SerializeField]
    private float m_fGlideDefaultSpeed;

    [SerializeField]
    private float m_fGlideDefaultTimer;

    public float m_fMoveSpeed;
    public float m_fGlideSpeed;
    public float m_fGlideTimer;

    public bool m_bGliding;

    private float m_fGlidingTimeChecker;

    PlayerState State;

    // Start is called before the first frame update
    void Start()
    {
        m_controller = GetComponent<CharacterController>(); 
        m_animator = GetComponent<Animator>();
        m_fMoveSpeed = m_fMoveDefaultSpeed;
        m_fGlideSpeed=m_fGlideDefaultSpeed;
        m_fGlideTimer= m_fGlideDefaultTimer;
        m_fGlidingTimeChecker = m_fGlideDefaultTimer;

        m_bGliding= false;
    }

    // Update is called once per frame
    void Update()
    {
        Glide();
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

    public void Glide()
    {
        if(true==m_bGliding)
        {
            transform.Translate(0f, 0f, m_fGlideSpeed * Time.deltaTime, Space.Self);
            m_animator.SetBool("Glide", true);

            m_fGlidingTimeChecker-=Time.deltaTime;

            if(m_fGlidingTimeChecker <= 0)
            {
                m_bGliding = false;
                m_fGlidingTimeChecker = m_fGlideTimer;
            }
            Debug.Log("gliding");
            State = PlayerState.Glide;
        }
        else
        {
            m_animator.SetBool("Glide", false);
            State = PlayerState.Idle;
        }
     // m_bGliding= true;
      //  transform.Translate(0f, 0f, m_fGlideSpeed*Time.deltaTime, Space.Self);
    }


    private void Rotate()
    {
        
    }
}
