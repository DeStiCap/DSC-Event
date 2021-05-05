using DSC.Core;
using UnityEngine;
using UnityEngine.Events;

namespace DSC.Event.Helper
{
    public class DSC_Event_RunEventsByEventString : MonoBehaviour
    {
        #region Variable

        #region Variable - Inspector

#if UNITY_EDITOR

        [TextField("Events Description", 3)]
        [SerializeField] string m_sDescription;

#endif

        [SerializeField] protected EventCondition[] m_arrCondition;
        [SerializeField] protected UnityEvent<string> m_hPreRunEvent;
        [SerializeField] protected UnityEvent<string> m_hRunEvent;
        [SerializeField] protected UnityEvent<string> m_hPostRunEvent;

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

        public virtual void RunEvent(string sValue)
        {
            if (!IsPassCondition())
                return;

            m_hPreRunEvent?.Invoke(sValue);
            m_hRunEvent?.Invoke(sValue);
            m_hPostRunEvent?.Invoke(sValue);
        }

        public void SetCondition(params EventCondition[] arrCondition)
        {
            m_arrCondition = arrCondition;
        }

        public void AddPreRunEvent(UnityAction<string> hAction)
        {
            m_hPreRunEvent?.AddListener(hAction);
        }

        public void RemovePreRunEvent(UnityAction<string> hAction)
        {
            m_hPreRunEvent?.RemoveListener(hAction);
        }

        public void RemoveAllPreRunEvent()
        {
            m_hPreRunEvent?.RemoveAllListeners();
        }

        public void AddRunEvent(UnityAction<string> hAction)
        {
            m_hRunEvent?.AddListener(hAction);
        }

        public void RemoveRunEvent(UnityAction<string> hAction)
        {
            m_hRunEvent?.RemoveListener(hAction);
        }

        public void RemoveAllRunEvent()
        {
            m_hRunEvent?.RemoveAllListeners();
        }

        public void AddPostRunEvent(UnityAction<string> hAction)
        {
            m_hPostRunEvent?.AddListener(hAction);
        }

        public void RemovePostRunEvent(UnityAction<string> hAction)
        {
            m_hPostRunEvent?.RemoveListener(hAction);
        }

        public void RemoveAllPostRunEvent()
        {
            m_hPostRunEvent?.RemoveAllListeners();
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
