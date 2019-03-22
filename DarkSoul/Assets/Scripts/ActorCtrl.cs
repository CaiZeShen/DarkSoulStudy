using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCtrl : MonoBehaviour {
    [SerializeField] private GameObject m_Modle;
    private Animator m_Animator;
    private PlayerInput m_PInput;

    private void Awake() {
        m_Animator = m_Modle.GetComponent<Animator>();
        m_PInput = GetComponent<PlayerInput>();
    }

    void Start() {

    }

    void Update() {
        m_Animator.SetFloat("forward", m_PInput.dMag);
        m_Modle.transform.forward = m_PInput.dVec;
    }


}
