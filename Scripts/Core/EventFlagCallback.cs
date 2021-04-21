using System.Collections.Generic;
using UnityEngine.Events;
using System;
using System.Linq;
using DSC.Core;

namespace DSC.Event
{
    public class EventFlagCallback<EventKey> : EventCallback<EventKey> where EventKey : unmanaged, Enum
    {
        #region Variable

        static IEnumerable<EventKey> m_ieAllKey;

        #endregion

        #region Main

        public EventFlagCallback() : base()
        {
            m_ieAllKey ??= Enum.GetValues(typeof(EventKey)).Cast<EventKey>();
        }

        protected override void MainAdd(EventKey hKey, UnityAction hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                AddThisEvent(hKey, hAction, eOrderType);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        AddThisEvent(hCheckKey, hAction, eOrderType);
                    }
                }
            }
        }

        protected override void MainRemove(EventKey hKey, UnityAction hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                RemoveThisEvent(hKey, hAction, eOrderType);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        RemoveThisEvent(hCheckKey, hAction, eOrderType);
                    }
                }
            }
        }

        public override void ClearEvent(EventKey hKey)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                ClearThisEvent(hKey);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        ClearThisEvent(hCheckKey);
                    }
                }
            }
        }

        public override void Run(EventKey hKey)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                RunThisEvent(hKey);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        RunThisEvent(hCheckKey);
                    }
                }
            }
        }

        #endregion
    }

    public class EventFlagCallback<EventKey, T0> : EventCallback<EventKey, T0> where EventKey : unmanaged, Enum
    {
        #region Variable

        static IEnumerable<EventKey> m_ieAllKey;

        #endregion

        #region Main

        public EventFlagCallback() : base()
        {
            m_ieAllKey ??= Enum.GetValues(typeof(EventKey)).Cast<EventKey>();
        }

        protected override void MainAdd(EventKey hKey, UnityAction<T0> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                AddThisEvent(hKey, hAction, eOrderType);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        AddThisEvent(hCheckKey, hAction, eOrderType);
                    }
                }
            }
        }

        protected override void MainRemove(EventKey hKey, UnityAction<T0> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                RemoveThisEvent(hKey, hAction, eOrderType);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        RemoveThisEvent(hCheckKey, hAction, eOrderType);
                    }
                }
            }
        }

        public override void ClearEvent(EventKey hKey)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                ClearThisEvent(hKey);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        ClearThisEvent(hCheckKey);
                    }
                }
            }
        }

        public override void Run(EventKey hKey, T0 arg0)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                RunThisEvent(hKey, arg0);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        RunThisEvent(hCheckKey, arg0);
                    }
                }
            }
        }

        #endregion
    }

    public class EventFlagCallback<EventKey, T0, T1> : EventCallback<EventKey, T0, T1> where EventKey : unmanaged, Enum
    {
        #region Variable

        static IEnumerable<EventKey> m_ieAllKey;

        #endregion

        #region Main

        public EventFlagCallback() : base()
        {
            m_ieAllKey ??= Enum.GetValues(typeof(EventKey)).Cast<EventKey>();
        }

        protected override void MainAdd(EventKey hKey, UnityAction<T0, T1> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                AddThisEvent(hKey, hAction, eOrderType);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        AddThisEvent(hCheckKey, hAction, eOrderType);
                    }
                }
            }
        }

        protected override void MainRemove(EventKey hKey, UnityAction<T0, T1> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                RemoveThisEvent(hKey, hAction, eOrderType);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        RemoveThisEvent(hCheckKey, hAction, eOrderType);
                    }
                }
            }
        }

        public override void ClearEvent(EventKey hKey)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                ClearThisEvent(hKey);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        ClearThisEvent(hCheckKey);
                    }
                }
            }
        }

        public override void Run(EventKey hKey, T0 arg0, T1 arg1)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                RunThisEvent(hKey, arg0, arg1);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        RunThisEvent(hCheckKey, arg0, arg1);
                    }
                }
            }
        }

        #endregion
    }

    public class EventFlagCallback<EventKey, T0, T1, T2> : EventCallback<EventKey, T0, T1, T2> where EventKey : unmanaged, Enum
    {
        #region Variable

        static IEnumerable<EventKey> m_ieAllKey;

        #endregion

        #region Main

        public EventFlagCallback() : base()
        {
            m_ieAllKey ??= Enum.GetValues(typeof(EventKey)).Cast<EventKey>();
        }

        protected override void MainAdd(EventKey hKey, UnityAction<T0, T1, T2> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                AddThisEvent(hKey, hAction, eOrderType);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        AddThisEvent(hCheckKey, hAction, eOrderType);
                    }
                }
            }
        }

        protected override void MainRemove(EventKey hKey, UnityAction<T0, T1, T2> hAction, EventOrder eOrderType = EventOrder.Normal)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                RemoveThisEvent(hKey, hAction, eOrderType);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        RemoveThisEvent(hCheckKey, hAction, eOrderType);
                    }
                }
            }
        }

        public override void ClearEvent(EventKey hKey)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                ClearThisEvent(hKey);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        ClearThisEvent(hCheckKey);
                    }
                }
            }
        }

        public override void Run(EventKey hKey, T0 arg0, T1 arg1, T2 arg2)
        {
            if (m_ieAllKey.Contains(hKey))
            {
                RunThisEvent(hKey, arg0, arg1, arg2);
            }
            else
            {
                foreach (var hCheckKey in m_ieAllKey)
                {
                    if (FlagUtility.HasFlagUnsafe(hKey, hCheckKey))
                    {
                        RunThisEvent(hCheckKey, arg0, arg1, arg2);
                    }
                }
            }
        }

        #endregion
    }
}
