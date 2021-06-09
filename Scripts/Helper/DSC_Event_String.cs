using DSC.Core;
using UnityEngine;
using UnityEngine.Events;

namespace DSC.Event.Helper
{
    public class DSC_Event_String : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector

#if UNITY_EDITOR

        [TextField("Events Description", 3)]
        [SerializeField] string m_sDescription;

#endif

        [Header("String Event")]
        [SerializeField] protected string m_sString;
        [SerializeField] protected EventCondition[] m_arrCondition;
        [SerializeField] protected UnityEvent<string> m_hEvent;

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

        public void SetString(string sString)
        {
            m_sString = sString;
        }

        public void SetString(int nString)
        {
            m_sString = nString.ToString();
        }

        public void SetString(float fString)
        {
            m_sString = fString.ToString();
        }

        public void RunEvent()
        {
            m_hEvent?.Invoke(m_sString);
        }

        public void RunEvent(string sString)
        {
            m_hEvent?.Invoke(sString);
        }

        public void RunEvent(int nString)
        {
            m_hEvent?.Invoke(nString.ToString());
        }

        public void RunEvent(float fString)
        {
            m_hEvent?.Invoke(fString.ToString());
        }

        public void SetEvent(UnityEvent<string> hEvent)
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