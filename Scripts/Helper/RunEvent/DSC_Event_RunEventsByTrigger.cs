using UnityEngine;
using UnityEngine.Events;
using DSC.Core;

namespace DSC.Event.Helper
{
    public class DSC_Event_RunEventsByTrigger : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector

#if UNITY_EDITOR

        [TextField("Events Description", 3)]
        [SerializeField] string m_sDescription;

#endif

        [TagField]
        [SerializeField] protected string[] m_arrTargetTag;

        [Header("Condition")]
        [SerializeField] protected EventCondition[] m_arrCondition;

        [Header("Event")]
        [SerializeField] protected UnityEvent m_hEnterEvent;
        [SerializeField] protected UnityEvent m_hStayEvent;
        [SerializeField] protected UnityEvent m_hExitEvent;

        [Header("Event Send Data")]
        [SerializeField] protected EventGameObject m_hEnterEventGameObject;
        [SerializeField] protected EventGameObject m_hStayEventGameObject;
        [SerializeField] protected EventGameObject m_hExitEventGameObject;

        #endregion

        #region Variable - Property

        public string[] targetTagArray
        {
            get { return m_arrTargetTag; }
            set
            {
                if (value == null)
                    return;

                m_arrTargetTag = value;
            }
        }

        #endregion

        protected EventConditionData m_hConditionData;

        #endregion

        #region Unity

        protected virtual void Awake()
        {
            m_hConditionData = new EventConditionData(transform);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (m_arrTargetTag.HasData() && !other.CompareTag(m_arrTargetTag))
                return;

            if (!IsPassCondition())
                return;

            m_hEnterEvent?.Invoke();
            m_hEnterEventGameObject?.Invoke(other.gameObject);
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (m_arrTargetTag.HasData() && !other.CompareTag(m_arrTargetTag))
                return;

            if (!IsPassCondition())
                return;

            m_hStayEvent?.Invoke();
            m_hStayEventGameObject?.Invoke(other.gameObject);
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (m_arrTargetTag.HasData() && !other.CompareTag(m_arrTargetTag))
                return;

            if (!IsPassCondition())
                return;

            m_hExitEvent?.Invoke();
            m_hExitEventGameObject?.Invoke(other.gameObject);
        }

        #endregion

        #region Events

        public void SetCondition(params EventCondition[] arrCondition)
        {
            m_arrCondition = arrCondition;
        }

        public void SetEnterEvent(UnityEvent hEvent)
        {
            m_hEnterEvent = hEvent;
        }

        public void SetEnterEvent(EventGameObject hEvent)
        {
            m_hEnterEventGameObject = hEvent;
        }

        public void SetStayEvent(UnityEvent hEvent)
        {
            m_hStayEvent = hEvent;
        }

        public void SetStayEvent(EventGameObject hEvent)
        {
            m_hStayEventGameObject = hEvent;
        }

        public void SetExitEvent(UnityEvent hEvent)
        {
            m_hExitEvent = hEvent;
        }

        public void SetExitEvent(EventGameObject hEvent)
        {
            m_hExitEventGameObject = hEvent;
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