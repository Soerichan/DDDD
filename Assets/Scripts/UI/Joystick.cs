using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //Ű����,����,��ġ�� �̺�Ʈ�� ������Ʈ���� ������ �ִ� ����� ����

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    [SerializeField]
    private RectTransform m_lever;
    private RectTransform m_rectTransform;

    [SerializeField]
    [Range(10f, 150f)]
    private float m_fLeverRange;

    [SerializeField]
    private PlayerController m_playerController;

    private Vector2 m_inputDir;
    private bool m_bIsInput;



    private void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        JoystickControll(eventData);
        m_bIsInput = true;

        //������Ʈ�� Ŭ���ؼ� �巡���ϴ� ���߿� ������ �̺�Ʈ
        //������ Ŭ���� ������ä�� ���콺�� ���߸� �̺�Ʈ�� ����������


    }

    public void OnDrag(PointerEventData eventData)
    {

        JoystickControll(eventData);

     
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_lever.anchoredPosition = Vector2.zero;
        m_bIsInput = false;
        m_playerController.Move(Vector2.zero);
      
    }

    private void JoystickControll(PointerEventData eventData)
    {
        var inputPos = eventData.position - m_rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < m_fLeverRange ? inputPos : inputPos.normalized * m_fLeverRange;
        m_lever.anchoredPosition = inputVector;
        m_inputDir = inputVector / m_fLeverRange;

        // ����������: �� ��ǲ�����ʹ� �ػ󵵷� ����������̶� �ʹ� ũ��. �� ���� 0�� 1������ ����ȭ�� ������ ��ȯ�ϰ�
        // �ػ󵵰� �ٸ� ȯ�濡���� ���� ��ǲ���� �ޱ� ����.
    }

    private void InputControlVector()
    {
        m_playerController.Move(m_inputDir);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(true==m_bIsInput)
        {
            InputControlVector();
        }
    }
}
