using System.Collections.Generic;
using UnityEngine.Events;
using DSC.Core;

namespace DSC.Event
{
    public class EventCallback<EventKey>
    {
        #region Variable

        protected Dictionary<EventKey, Dictionary<EventOrder, UnityAction>> m_dicActData;

        #endregion

        #region Main

        /// <summary>
        /// Add callback to this event.
        /// </summary>
        public void Add(EventKey eventKey, UnityAction action)
        {
            MainAdd(eventKey, action);
        }

        /// <summary>
        /// Add callback to this event.
        /// </summary>
        public void Add(EventKey eventKey, UnityAction action, EventOrder orderType)
        {
            MainAdd(eventKey, action, orderType);
        }

        protected virtual void MainAdd(EventKey hKey, UnityAction hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            AddThisEvent(hKey, hAction, eOrderType);
        }

        /// <summary>
        /// Remove callback from this event.
        /// </summary>
        public void Remove(EventKey eventKey, UnityAction action)
        {
            MainRemove(eventKey, action);
        }

        /// <summary>
        /// Remove callback from this event.
        /// </summary>
        public void Remove(EventKey eventKey, UnityAction action, EventOrder orderType)
        {
            MainRemove(eventKey, action, orderType);
        }

        protected virtual void MainRemove(EventKey hKey, UnityAction hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            RemoveThisEvent(hKey, hAction, eOrderType);
        }

        /// <summary>
        /// Clear all event callback in data.
        /// </summary>
        public void ClearAll()
        {
            if (m_dicActData == null || m_dicActData.Count <= 0)
                return;

            m_dicActData.Clear();
        }

        /// <summary>
        /// Clear all callback in this event.
        /// </summary>
        public virtual void ClearEvent(EventKey hKey)
        {
            ClearThisEvent(hKey);
        }

        /// <summary>
        /// Run event callback.
        /// </summary>
        public virtual void Run(EventKey hKey)
        {
            RunThisEvent(hKey);
        }

        #endregion

        #region Helper

        protected void AddThisEvent(EventKey hKey, UnityAction hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            m_dicActData ??= new Dictionary<EventKey, Dictionary<EventOrder, UnityAction>>();

            if (m_dicActData.TryGetValue(hKey, out var hOutData))
            {
                if (hOutData.TryGetValue(eOrderType, out var hOutAction))
                {
                    hOutAction += hAction;
                    hOutData[eOrderType] = hOutAction;
                }
                else
                {
                    hOutData.Add(eOrderType, hAction);
                }

                m_dicActData[hKey] = hOutData;
            }
            else
            {
                var hNewData = new Dictionary<EventOrder, UnityAction>();
                hNewData.Add(eOrderType, hAction);
                m_dicActData.Add(hKey, hNewData);
            }
        }

        protected void RemoveThisEvent(EventKey hKey, UnityAction hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];
            if (!hData.ContainsKey(eOrderType))
                return;

            var hAct = hData[eOrderType];
            hAct -= hAction;
            hData[eOrderType] = hAct;

            m_dicActData[hKey] = hData;
        }

        protected void ClearThisEvent(EventKey hKey)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];
            hData.Clear();
            m_dicActData[hKey] = hData;
        }

        protected void RunThisEvent(EventKey hKey)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];

            if (hData.TryGetValue(EventOrder.PreEarly, out var hPreEarlyAction))
            {
                hPreEarlyAction?.Invoke();
            }

            if (hData.TryGetValue(EventOrder.Early, out var hEarlyAction))
            {
                hEarlyAction?.Invoke();
            }

            if (hData.TryGetValue(EventOrder.PostEalry, out var hPostEarlyAction))
            {
                hPostEarlyAction?.Invoke();
            }

            if (hData.TryGetValue(EventOrder.PreNormal, out var hPreNormalAction))
            {
                hPreNormalAction?.Invoke();
            }

            if (hData.TryGetValue(EventOrder.Normal, out var hNormalAction))
            {
                hNormalAction?.Invoke();
            }

            if (hData.TryGetValue(EventOrder.PostNormal, out var hPostNormalAction))
            {
                hPostNormalAction?.Invoke();
            }

            if (hData.TryGetValue(EventOrder.PreLate, out var hPreLateAction))
            {
                hPreLateAction?.Invoke();
            }

            if (hData.TryGetValue(EventOrder.Late, out var hLateAction))
            {
                hLateAction?.Invoke();
            }

            if (hData.TryGetValue(EventOrder.PostLate, out var hPostLateAction))
            {
                hPostLateAction?.Invoke();
            }
        }

        #endregion
    }

    public class EventCallback<EventKey, T0>
    {
        #region Variable

        protected Dictionary<EventKey, Dictionary<EventOrder, UnityAction<T0>>> m_dicActData;

        #endregion

        #region Main

        /// <summary>
        /// Add callback to this event.
        /// </summary>
        public void Add(EventKey eventKey, UnityAction<T0> action)
        {
            MainAdd(eventKey, action);
        }

        /// <summary>
        /// Add callback to this event.
        /// </summary>
        public void Add(EventKey eventKey, UnityAction<T0> action, EventOrder orderType)
        {
            MainAdd(eventKey, action, orderType);
        }

        protected virtual void MainAdd(EventKey hKey, UnityAction<T0> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            AddThisEvent(hKey, hAction, eOrderType);
        }

        /// <summary>
        /// Remove callback from this event.
        /// </summary>
        public void Remove(EventKey eventKey, UnityAction<T0> action)
        {
            MainRemove(eventKey, action);
        }

        /// <summary>
        /// Remove callback from this event.
        /// </summary>
        public void Remove(EventKey eventKey, UnityAction<T0> action, EventOrder orderType)
        {
            MainRemove(eventKey, action, orderType);
        }

        protected virtual void MainRemove(EventKey hKey, UnityAction<T0> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            RemoveThisEvent(hKey, hAction, eOrderType);
        }

        /// <summary>
        /// Clear all event callback in data.
        /// </summary>
        public void ClearAll()
        {
            if (m_dicActData == null || m_dicActData.Count <= 0)
                return;

            m_dicActData.Clear();
        }

        /// <summary>
        /// Clear all callback in this event.
        /// </summary>
        public virtual void ClearEvent(EventKey hKey)
        {
            ClearThisEvent(hKey);
        }

        /// <summary>
        /// Run event callback.
        /// </summary>
        public virtual void Run(EventKey hKey, T0 arg0)
        {
            RunThisEvent(hKey, arg0);
        }

        #endregion

        #region Helper

        protected void AddThisEvent(EventKey hKey, UnityAction<T0> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            m_dicActData ??= new Dictionary<EventKey, Dictionary<EventOrder, UnityAction<T0>>>();

            if (m_dicActData.TryGetValue(hKey, out var hOutData))
            {
                if (hOutData.TryGetValue(eOrderType, out var hOutAction))
                {
                    hOutAction += hAction;
                    hOutData[eOrderType] = hOutAction;
                }
                else
                {
                    hOutData.Add(eOrderType, hAction);
                }

                m_dicActData[hKey] = hOutData;
            }
            else
            {
                var hNewData = new Dictionary<EventOrder, UnityAction<T0>>();
                hNewData.Add(eOrderType, hAction);
                m_dicActData.Add(hKey, hNewData);
            }
        }

        protected void RemoveThisEvent(EventKey hKey, UnityAction<T0> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];
            if (!hData.ContainsKey(eOrderType))
                return;

            var hAct = hData[eOrderType];
            hAct -= hAction;
            hData[eOrderType] = hAct;

            m_dicActData[hKey] = hData;
        }

        protected void ClearThisEvent(EventKey hKey)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];
            hData.Clear();
            m_dicActData[hKey] = hData;
        }

        protected void RunThisEvent(EventKey hKey, T0 arg0)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];

            if (hData.TryGetValue(EventOrder.PreEarly, out var hPreEarlyAction))
            {
                hPreEarlyAction?.Invoke(arg0);
            }

            if (hData.TryGetValue(EventOrder.Early, out var hEarlyAction))
            {
                hEarlyAction?.Invoke(arg0);
            }

            if (hData.TryGetValue(EventOrder.PostEalry, out var hPostEarlyAction))
            {
                hPostEarlyAction?.Invoke(arg0);
            }

            if (hData.TryGetValue(EventOrder.PreNormal, out var hPreNormalAction))
            {
                hPreNormalAction?.Invoke(arg0);
            }

            if (hData.TryGetValue(EventOrder.Normal, out var hNormalAction))
            {
                hNormalAction?.Invoke(arg0);
            }

            if (hData.TryGetValue(EventOrder.PostNormal, out var hPostNormalAction))
            {
                hPostNormalAction?.Invoke(arg0);
            }

            if (hData.TryGetValue(EventOrder.PreLate, out var hPreLateAction))
            {
                hPreLateAction?.Invoke(arg0);
            }

            if (hData.TryGetValue(EventOrder.Late, out var hLateAction))
            {
                hLateAction?.Invoke(arg0);
            }

            if (hData.TryGetValue(EventOrder.PostLate, out var hPostLateAction))
            {
                hPostLateAction?.Invoke(arg0);
            }
        }

        #endregion
    }

    public class EventCallback<EventKey, T0, T1>
    {
        #region Variable

        protected Dictionary<EventKey, Dictionary<EventOrder, UnityAction<T0, T1>>> m_dicActData;

        #endregion

        #region Main

        /// <summary>
        /// Add callback to this event.
        /// </summary>
        public void Add(EventKey eventKey, UnityAction<T0, T1> action)
        {
            MainAdd(eventKey, action);
        }

        /// <summary>
        /// Add callback to this event.
        /// </summary>
        public void Add(EventKey eventKey, UnityAction<T0, T1> action, EventOrder orderType)
        {
            MainAdd(eventKey, action, orderType);
        }

        protected virtual void MainAdd(EventKey hKey, UnityAction<T0, T1> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            AddThisEvent(hKey, hAction, eOrderType);
        }

        /// <summary>
        /// Remove callback from this event.
        /// </summary>
        public void Remove(EventKey eventKey, UnityAction<T0, T1> action)
        {
            MainRemove(eventKey, action);
        }

        /// <summary>
        /// Remove callback from this event.
        /// </summary>
        public void Remove(EventKey eventKey, UnityAction<T0, T1> action, EventOrder orderType)
        {
            MainRemove(eventKey, action, orderType);
        }

        protected virtual void MainRemove(EventKey hKey, UnityAction<T0, T1> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            RemoveThisEvent(hKey, hAction, eOrderType);
        }

        /// <summary>
        /// Clear all event callback in data.
        /// </summary>
        public void ClearAll()
        {
            if (m_dicActData == null || m_dicActData.Count <= 0)
                return;

            m_dicActData.Clear();
        }

        /// <summary>
        /// Clear all callback in this event.
        /// </summary>
        public virtual void ClearEvent(EventKey hKey)
        {
            ClearThisEvent(hKey);
        }

        /// <summary>
        /// Run event callback.
        /// </summary>
        public virtual void Run(EventKey hKey, T0 arg0, T1 arg1)
        {
            RunThisEvent(hKey, arg0, arg1);
        }

        #endregion

        #region Helper

        protected void AddThisEvent(EventKey hKey, UnityAction<T0, T1> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            m_dicActData ??= new Dictionary<EventKey, Dictionary<EventOrder, UnityAction<T0, T1>>>();

            if (m_dicActData.TryGetValue(hKey, out var hOutData))
            {
                if (hOutData.TryGetValue(eOrderType, out var hOutAction))
                {
                    hOutAction += hAction;
                    hOutData[eOrderType] = hOutAction;
                }
                else
                {
                    hOutData.Add(eOrderType, hAction);
                }

                m_dicActData[hKey] = hOutData;
            }
            else
            {
                var hNewData = new Dictionary<EventOrder, UnityAction<T0, T1>>();
                hNewData.Add(eOrderType, hAction);
                m_dicActData.Add(hKey, hNewData);
            }
        }

        protected void RemoveThisEvent(EventKey hKey, UnityAction<T0, T1> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];
            if (!hData.ContainsKey(eOrderType))
                return;

            var hAct = hData[eOrderType];
            hAct -= hAction;
            hData[eOrderType] = hAct;

            m_dicActData[hKey] = hData;
        }

        protected void ClearThisEvent(EventKey hKey)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];
            hData.Clear();
            m_dicActData[hKey] = hData;
        }

        protected void RunThisEvent(EventKey hKey, T0 arg0, T1 arg1)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];

            if (hData.TryGetValue(EventOrder.PreEarly, out var hPreEarlyAction))
            {
                hPreEarlyAction?.Invoke(arg0, arg1);
            }

            if (hData.TryGetValue(EventOrder.Early, out var hEarlyAction))
            {
                hEarlyAction?.Invoke(arg0, arg1);
            }

            if (hData.TryGetValue(EventOrder.PostEalry, out var hPostEarlyAction))
            {
                hPostEarlyAction?.Invoke(arg0, arg1);
            }

            if (hData.TryGetValue(EventOrder.PreNormal, out var hPreNormalAction))
            {
                hPreNormalAction?.Invoke(arg0, arg1);
            }

            if (hData.TryGetValue(EventOrder.Normal, out var hNormalAction))
            {
                hNormalAction?.Invoke(arg0, arg1);
            }

            if (hData.TryGetValue(EventOrder.PostNormal, out var hPostNormalAction))
            {
                hPostNormalAction?.Invoke(arg0, arg1);
            }

            if (hData.TryGetValue(EventOrder.PreLate, out var hPreLateAction))
            {
                hPreLateAction?.Invoke(arg0, arg1);
            }

            if (hData.TryGetValue(EventOrder.Late, out var hLateAction))
            {
                hLateAction?.Invoke(arg0, arg1);
            }

            if (hData.TryGetValue(EventOrder.PostLate, out var hPostLateAction))
            {
                hPostLateAction?.Invoke(arg0, arg1);
            }
        }

        #endregion
    }

    public class EventCallback<EventKey, T0, T1, T2>
    {
        #region Variable

        protected Dictionary<EventKey, Dictionary<EventOrder, UnityAction<T0, T1, T2>>> m_dicActData;

        #endregion

        #region Main

        /// <summary>
        /// Add callback to this event.
        /// </summary>
        public void Add(EventKey eventKey, UnityAction<T0, T1, T2> action)
        {
            MainAdd(eventKey, action);
        }

        /// <summary>
        /// Add callback to this event.
        /// </summary>
        public void Add(EventKey eventKey, UnityAction<T0, T1, T2> action, EventOrder orderType)
        {
            MainAdd(eventKey, action, orderType);
        }

        protected virtual void MainAdd(EventKey hKey, UnityAction<T0, T1, T2> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            AddThisEvent(hKey, hAction, eOrderType);
        }

        /// <summary>
        /// Remove callback from this event.
        /// </summary>
        public void Remove(EventKey eventKey, UnityAction<T0, T1, T2> action)
        {
            MainRemove(eventKey, action);
        }

        /// <summary>
        /// Remove callback from this event.
        /// </summary>
        public void Remove(EventKey eventKey, UnityAction<T0, T1, T2> action, EventOrder orderType)
        {
            MainRemove(eventKey, action, orderType);
        }

        protected virtual void MainRemove(EventKey hKey, UnityAction<T0, T1, T2> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            RemoveThisEvent(hKey, hAction, eOrderType);
        }

        /// <summary>
        /// Clear all event callback in data.
        /// </summary>
        public void ClearAll()
        {
            if (m_dicActData == null || m_dicActData.Count <= 0)
                return;

            m_dicActData.Clear();
        }

        /// <summary>
        /// Clear all callback in this event.
        /// </summary>
        public virtual void ClearEvent(EventKey hKey)
        {
            ClearThisEvent(hKey);
        }

        /// <summary>
        /// Run event callback.
        /// </summary>
        public virtual void Run(EventKey hKey, T0 arg0, T1 arg1, T2 arg2)
        {
            RunThisEvent(hKey, arg0, arg1, arg2);
        }

        #endregion

        #region Helper

        protected void AddThisEvent(EventKey hKey, UnityAction<T0, T1, T2> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            m_dicActData ??= new Dictionary<EventKey, Dictionary<EventOrder, UnityAction<T0, T1, T2>>>();

            if (m_dicActData.TryGetValue(hKey, out var hOutData))
            {
                if (hOutData.TryGetValue(eOrderType, out var hOutAction))
                {
                    hOutAction += hAction;
                    hOutData[eOrderType] = hOutAction;
                }
                else
                {
                    hOutData.Add(eOrderType, hAction);
                }

                m_dicActData[hKey] = hOutData;
            }
            else
            {
                var hNewData = new Dictionary<EventOrder, UnityAction<T0, T1, T2>>();
                hNewData.Add(eOrderType, hAction);
                m_dicActData.Add(hKey, hNewData);
            }
        }

        protected void RemoveThisEvent(EventKey hKey, UnityAction<T0, T1, T2> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];
            if (!hData.ContainsKey(eOrderType))
                return;

            var hAct = hData[eOrderType];
            hAct -= hAction;
            hData[eOrderType] = hAct;

            m_dicActData[hKey] = hData;
        }

        protected void ClearThisEvent(EventKey hKey)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];
            hData.Clear();
            m_dicActData[hKey] = hData;
        }

        protected void RunThisEvent(EventKey hKey, T0 arg0, T1 arg1, T2 arg2)
        {
            if (!m_dicActData.HasKey(hKey))
                return;

            var hData = m_dicActData[hKey];

            if (hData.TryGetValue(EventOrder.PreEarly, out var hPreEarlyAction))
            {
                hPreEarlyAction?.Invoke(arg0, arg1, arg2);
            }

            if (hData.TryGetValue(EventOrder.Early, out var hEarlyAction))
            {
                hEarlyAction?.Invoke(arg0, arg1, arg2);
            }

            if (hData.TryGetValue(EventOrder.PostEalry, out var hPostEarlyAction))
            {
                hPostEarlyAction?.Invoke(arg0, arg1, arg2);
            }

            if (hData.TryGetValue(EventOrder.PreNormal, out var hPreNormalAction))
            {
                hPreNormalAction?.Invoke(arg0, arg1, arg2);
            }

            if (hData.TryGetValue(EventOrder.Normal, out var hNormalAction))
            {
                hNormalAction?.Invoke(arg0, arg1, arg2);
            }

            if (hData.TryGetValue(EventOrder.PostNormal, out var hPostNormalAction))
            {
                hPostNormalAction?.Invoke(arg0, arg1, arg2);
            }

            if (hData.TryGetValue(EventOrder.PreLate, out var hPreLateAction))
            {
                hPreLateAction?.Invoke(arg0, arg1, arg2);
            }

            if (hData.TryGetValue(EventOrder.Late, out var hLateAction))
            {
                hLateAction?.Invoke(arg0, arg1, arg2);
            }

            if (hData.TryGetValue(EventOrder.PostLate, out var hPostLateAction))
            {
                hPostLateAction?.Invoke(arg0, arg1, arg2);
            }
        }

        #endregion

    }
}