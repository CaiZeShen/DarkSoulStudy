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
    // 持续的信号
    public bool run;
    // 一次的信号
    public bool jump;
    private bool m_LastJump;

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

        Vector2 tmp = Square2Circle(new Vector2(dRight, dUp));
        float dUp2 = tmp.y;
        float dRight2 = tmp.x;

        dMag = Mathf.Sqrt(dUp2 * dUp2 + dRight2 * dRight2);
        dVec = dUp2 * transform.forward + dRight2 * transform.right;

        run = Input.GetKey(keyA);

        bool newJump = Input.GetKey(keyB);
        if (newJump != m_LastJump && newJump) {
            jump = true;
        } else {
            jump = false;
        }
        m_LastJump = newJump;

    }

    Vector2 Square2Circle(Vector2 input) {
        Vector2 output = Vector2.zero;

        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2f);

        return output;
    }
}
