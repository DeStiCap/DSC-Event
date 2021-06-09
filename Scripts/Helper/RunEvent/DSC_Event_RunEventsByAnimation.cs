using UnityEngine;
using DSC.Core;
using UnityEngine.Events;

namespace DSC.Event.Helper
{
    [RequireComponent(typeof(Animation))]
    public class DSC_Event_RunEventsByAnimation : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector

#if UNITY_EDITOR

        [TextField("Events Description", 3)]
        [SerializeField] string m_sDescription;

#endif

        [Header("Events")]
        [SerializeField] protected EventCondition[] m_arrCondition;
        [SerializeField] protected UnityEvent m_hStartEvent;
        [SerializeField] protected UnityEvent m_hEndEvent;

        #endregion

        protected EventConditionData m_hConditionData;

        protected Animation m_hAnimation;
        protected bool m_bIsPlaying;

        #endregion

        #region Unity

        protected virtual void Awake()
        {
            m_hAnimation = GetComponent<Animation>();

            m_hConditionData = new EventConditionData(transform);
        }

        protected virtual void OnDisable()
        {
            m_bIsPlaying = false;
        }

        protected virtual void Update()
        {
            if (m_bIsPlaying != m_hAnimation.isPlaying)
            {
                if (!m_bIsPlaying)
                {
                    m_hStartEvent?.Invoke();
                }
                else
                {
                    m_hEndEvent?.Invoke();
                }

                m_bIsPlaying = m_hAnimation.isPlaying;
            }
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
