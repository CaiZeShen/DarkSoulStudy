using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public bool inputEnble;

    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    public float dUp;
    public float dRight;

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
    }
}
