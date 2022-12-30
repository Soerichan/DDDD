using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSet : MonoBehaviour
{
    private void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
        Application.targetFrameRate = 60;
#endif
    }
}
