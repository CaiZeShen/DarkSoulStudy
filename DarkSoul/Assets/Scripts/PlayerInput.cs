using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [Header("===== 按键设置 =====")]
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";
    public string keyA;
    public string keyB;
    public string keyC;
    public string keyD;

    [Header("===== 信号输出 =====")]
    public float dUp;
    public float dRight;
    public float dMag;
    public Vector3 dVec;
    public bool run;

    [Header("===== 其他 =====")]
    public bool inputEnble;

    private float m_TargetDUp;
    private float m_VelocityDUp;
    private float m_TargetDRight;
    private float m_VelocityDRight;

    void Start() {

    }

    void Update() {
        m_TargetDUp = (Input.GetKey(keyUp) ? 1 : 0) - (Input.GetKey(keyDown) ? 1 : 0);
        m_TargetDRight = (Input.GetKey(keyRight) ? 1 : 0) - (Input.GetKey(keyLeft) ? 1 : 0);

        if (inputEnble == false) {
            m_TargetDUp = 0;
        }

        dUp = Mathf.SmoothDamp(dUp, m_TargetDUp, ref m_VelocityDUp, 0.1f);
        dRight = Mathf.SmoothDamp(dRight, m_TargetDRight, ref m_VelocityDRight, 0.1f);

        dMag = Mathf.Sqrt(dUp * dUp + dRight * dRight);
        dVec = dUp * transform.forward + dRight * transform.right;

        run = Input.GetKey(keyA);
    }
}
