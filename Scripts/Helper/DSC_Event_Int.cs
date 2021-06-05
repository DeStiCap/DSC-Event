using DSC.Core;
using UnityEngine;
using UnityEngine.Events;

namespace DSC.Event.Helper
{
    public class DSC_Event_Int : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector

#if UNITY_EDITOR

        [TextField("Events Description", 3)]
        [SerializeField] string m_sDescription;

#endif

        [Header("Int Event")]
        [SerializeField] protected int m_nInt;
        [SerializeField] protected EventCondition[] m_arrCondition;
        [SerializeField] protected UnityEvent<int> m_hEvent;

        #endregion

        protected EventConditionData m_hConditionData;

        #endregion

        #region Main

        public void SetInt(int nInt)
        {
            m_nInt = nInt;
        }

        public void SetInt(float fInt)
        {
            m_nInt = Mathf.RoundToInt(fInt);
        }

        public void SetInt(string sInt)
        {
            if (!int.TryParse(sInt, out int nResult))
                return;

            m_nInt = nResult;
        }

        public void RunEvent()
        {
            m_hEvent?.Invoke(m_nInt);
        }

        public void RunEvent(int nInt)
        {
            m_hEvent?.Invoke(nInt);
        }

        public void RunEvent(float fInt)
        {
            m_hEvent?.Invoke(Mathf.RoundToInt(fInt));
        }

        public void RunEvent(string sInt)
        {
            if (!int.TryParse(sInt, out int nResult))
                return;

            m_hEvent?.Invoke(nResult);
        }

        public void SetEvent(UnityEvent<int> hEvent)
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