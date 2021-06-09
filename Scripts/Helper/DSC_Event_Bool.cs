using DSC.Core;
using UnityEngine;
using UnityEngine.Events;

namespace DSC.Event.Helper
{
    public class DSC_Event_Bool : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector

#if UNITY_EDITOR

        [TextField("Events Description", 3)]
        [SerializeField] string m_sDescription;

#endif

        [Header("Bool Event")]
        [SerializeField] protected bool m_bBool;
        [SerializeField] protected EventCondition[] m_arrCondition;
        [SerializeField] protected UnityEvent<bool> m_hEvent;

        #endregion

        protected EventConditionData m_hConditionData;

        #endregion

        #region Unity

        protected virtual void Awake()
        {
            m_hConditionData = new EventConditionData(transform);
        }

        #endregion

        #region Main

        public void SetBool(bool bBool)
        {
            m_bBool = bBool;
        }

        public void RunEvent()
        {
            m_hEvent?.Invoke(m_bBool);
        }

        public void RunEvent(bool bBool)
        {
            m_hEvent?.Invoke(bBool);
        }

        public void SetEvent(UnityEvent<bool> hEvent)
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