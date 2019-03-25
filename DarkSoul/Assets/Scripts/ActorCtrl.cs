﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCtrl : MonoBehaviour {
    public float moveSpeed = 1;
    public float runMultiplier = 2;
    [SerializeField] private GameObject m_Modle;
    private Animator m_Animator;
    private PlayerInput m_PInput;
    private Rigidbody m_Rigidbody;
    private Vector3 m_MovingVec;

    private void Awake() {
        m_Animator = m_Modle.GetComponent<Animator>();
        m_PInput = GetComponent<PlayerInput>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Start() {

    }

    void Update() {
        m_Animator.SetFloat("forward", m_PInput.dMag * (m_PInput.run ? 2 : 1));

        // 设置旋转
        if (m_PInput.dMag > 0.1f) 
            m_Modle.transform.forward = m_PInput.dVec ;

        m_MovingVec = m_Modle.transform.forward * m_PInput.dMag * moveSpeed * (m_PInput.run ? runMultiplier : 1);
    }

    private void FixedUpdate() {
        //m_Rigidbody.position += movingVec * Time.fixedDeltaTime;
        m_Rigidbody.velocity = new Vector3(m_MovingVec.x, m_Rigidbody.velocity.y, m_MovingVec.z) ;
    }

}
