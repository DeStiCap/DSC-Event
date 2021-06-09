using DSC.Core;
using UnityEngine;
using UnityEngine.Events;

namespace DSC.Event.Helper
{
    public class DSC_Event_Float : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector

#if UNITY_EDITOR

        [TextField("Events Description", 3)]
        [SerializeField] string m_sDescription;

#endif

        [Header("Float Event")]
        [SerializeField] protected float m_fFloat;
        [SerializeField] protected EventCondition[] m_arrCondition;
        [SerializeField] protected UnityEvent<float> m_hEvent;

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

        public void SetFloat(float fFloat)
        {
            m_fFloat = fFloat;
        }

        public void SetFloat(int nFloat)
        {
            m_fFloat = nFloat;
        }

        public void SetFloat(string sFloat)
        {
            if (!float.TryParse(sFloat, out float fResult))
                return;

            m_fFloat = fResult;
        }

        public void RunEvent()
        {
            m_hEvent?.Invoke(m_fFloat);
        }

        public void RunEvent(float fFloat)
        {
            m_hEvent?.Invoke(fFloat);
        }

        public void RunEvent(int nFloat)
        {
            m_hEvent?.Invoke(nFloat);
        }

        public void RunEvent(string sFloat)
        {
            if (!float.TryParse(sFloat, out float fResult))
                return;

            m_hEvent?.Invoke(fResult);
        }

        public void SetEvent(UnityEvent<float> hEvent)
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