﻿using UnityEngine;
using UnityEngine.Events;
using DSC.Core;

namespace DSC.Event.Helper
{
    public class DSC_Event_RunEventsByTime : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649
        
        [Header("Time Event")]
        [Min(0)]
        [SerializeField] protected float m_fWaitDuration;
        [SerializeField] protected EventCondition[] m_arrCondition;
        [SerializeField] protected UnityEvent m_hEvent;

        [Header("Option")]
        [SerializeField] protected bool m_bRunOnlyOne = true;
        [SerializeField] protected bool m_bResetCountWhenRunSuccess = true;
        [SerializeField] protected bool m_bStartCountOnEnable;
        [SerializeField] protected bool m_bResetCountOnDisable;
        [SerializeField] protected bool m_bUseRealTime;

        [Header("Runtime Data")]
        [LabelName("Current Time Count")]
        [ReadOnlyField]
        [SerializeField] protected float m_fCurrentTimeCount;
        [LabelName("Counting")]
        [ReadOnlyField]
        [SerializeField] protected bool m_bCounting;

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        public float waitDuration
        {
            get { return m_fWaitDuration; }
            set
            {
                m_fWaitDuration = value;
                if (m_fWaitDuration < 0)
                    m_fWaitDuration = 0;
            }
        }

        public bool countingTime { get { return m_bCounting; } set { m_bCounting = value; } }

        public bool runOnlyOne { get { return m_bRunOnlyOne; } set { m_bRunOnlyOne = value; } }

        public bool startCountOnEnable { get { return m_bStartCountOnEnable; } set { m_bStartCountOnEnable = value; } }

        public bool resetCountOnDisable { get { return m_bResetCountOnDisable; } set { m_bResetCountOnDisable = value; } }

        public bool useRealTime { get { return m_bUseRealTime; } set { m_bUseRealTime = value; } }

        #endregion

        protected EventConditionData m_hConditionData;

        #endregion

        #region Base - Mono

        protected virtual void Awake()
        {
            m_hConditionData = new EventConditionData(transform);
        }

        protected virtual void OnEnable()
        {
            if (m_bStartCountOnEnable)
            {
                m_bCounting = true;
            }
        }

        protected virtual void OnDisable()
        {
            if (m_bResetCountOnDisable)
            {
                ResetTimeCount();
            }
        }

        protected virtual void Update()
        {
            if (m_bCounting)
            {
                m_fCurrentTimeCount += m_bUseRealTime ? Time.unscaledDeltaTime : Time.deltaTime;

                if(m_fCurrentTimeCount >= m_fWaitDuration)
                {
                    if (IsPassCondition())
                        RunEvent();
                    else if (m_bResetCountWhenRunSuccess)
                        return;

                    if (m_bRunOnlyOne)
                        m_bCounting = false;

                    ResetTimeCount();
                }
            }
        }

        #endregion

        #region Events

        public void ResetTimeCount()
        {
            m_fCurrentTimeCount = 0;
        }

        public void StartTimeCount()
        {
            ResetTimeCount();
            m_bCounting = true;
        }

        public void RunEvent()
        {
            m_hEvent?.Invoke();
        }

        public void SetEvent(UnityEvent hEvent)
        {
            m_hEvent = hEvent;
        }

        #endregion

        #region Helper

        protected bool IsPassCondition()
        {
            return m_arrCondition.PassAllCondition(m_hConditionData);
        }

        #endregion

    }
}