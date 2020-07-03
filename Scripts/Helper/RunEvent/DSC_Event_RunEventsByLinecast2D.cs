using UnityEngine;
using UnityEngine.Events;
using DSC.Core;

namespace DSC.Event.Helper
{
    public class DSC_Event_RunEventsByLinecast2D : BaseRunEventByPhysic
    {
        #region Variable

        #region Variable - Inspector
#pragma warning disable 0649

        [Header("Linecast")]
        [SerializeField] protected Transform m_hOriginPosition;
        [SerializeField] protected Transform m_hDestinationPosition;
        [SerializeField] protected LayerMask m_eTargetLayer = -1;
        [TagField]
        [SerializeField] protected string[] m_arrTargetTag;

        [Header("Option")]
        [SerializeField] protected GameObject[] m_arrIgnoreTarget;
        [SerializeField] protected bool m_bCheckUpdate = true;
        [SerializeField] protected UpdateType m_eUpdateType = UpdateType.FixedUpdate;

        [Header("Event")]
        [SerializeField] protected EventCondition[] m_arrCondition;
        [SerializeField] protected UnityEvent m_hHitEvent;
        [SerializeField] protected UnityEvent m_hNotHitEvent;
        [SerializeField] protected UnityEvent m_hNotTargetTagHitEvent;

        [Header("Event Send Data")]
        [SerializeField] protected EventGameObject m_hHitEventGameObject;
        [SerializeField] protected EventGameObject m_hNotTargetTagHitEventGameObject;

#if UNITY_EDITOR
        [Header("Debug")]
        [SerializeField] protected bool m_bAlwayShowGizmos;
        [SerializeField] protected Color m_hGizmosColor = Color.green;
#endif

#pragma warning restore 0649
        #endregion

        #region Variable - Property

        protected override EventConditionData eventConditionData { get; set; }
        protected override GameObject[] ignoreTargetArray { get { return m_arrIgnoreTarget; } set { m_arrIgnoreTarget = value; } }
        protected override bool checkUpdate { get { return m_bCheckUpdate; } set { m_bCheckUpdate = value; } }
        protected override UpdateType updateType { get { return m_eUpdateType; } set { m_eUpdateType = value; } }

        public LayerMask targetLayer { get { return m_eTargetLayer; } set { m_eTargetLayer = value; } }
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

        #endregion

        #region Base - Override

        protected override void CheckPhysic()
        {
            CheckLinecast();
        }

        #endregion

        #region Events

        public virtual void CheckLinecast()
        {
            if (!m_arrCondition.PassAllCondition(eventConditionData))
                return;

            Vector2 vPos = m_hOriginPosition != null ? m_hOriginPosition.position : transform.position;
            Vector2 vDestination = m_hDestinationPosition != null ? m_hDestinationPosition.position : transform.position;

            var hHit = Physics2D.Linecast(vPos, vDestination, m_eTargetLayer);
            
            if(hHit.collider != null)
            {
                if(m_arrTargetTag.HasData() && !hHit.transform.gameObject.CompareTag(m_arrTargetTag))
                {
                    m_hNotTargetTagHitEvent?.Invoke();
                    m_hNotTargetTagHitEventGameObject?.Invoke(hHit.transform.gameObject);
                    return;
                }

                m_hHitEvent?.Invoke();
                m_hHitEventGameObject?.Invoke(hHit.transform.gameObject);
            }
            else
            {
                m_hNotHitEvent?.Invoke();
            }
        }

        #endregion

        #region Editor Only
#if UNITY_EDITOR

        void OnDrawGizmos()
        {
            if (!m_bAlwayShowGizmos)
                return;

            ShowGizmos();
        }

        void OnDrawGizmosSelected()
        {
            if (m_bAlwayShowGizmos)
                return;

            ShowGizmos();
        }

        void ShowGizmos()
        {
            Vector2 vPos = m_hOriginPosition != null ? m_hOriginPosition.position : transform.position;
            Vector2 vDestination = m_hDestinationPosition != null ? m_hDestinationPosition.position : transform.position;

            Gizmos.color = m_hGizmosColor;
            Gizmos.DrawLine(vPos, vDestination);
        }

#endif
        #endregion
    }
}