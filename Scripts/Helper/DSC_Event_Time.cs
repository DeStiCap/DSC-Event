using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DSC.Core;

namespace DSC.Event
{
    public class DSC_Event_Time : MonoBehaviour
    {
        #region Events

        public void SetTimeScale(float fTimeScale)
        {
            DSC_Time.ChangeTimeScale(fTimeScale);
        }

        public void SetUnityTimeScale(float fTimeScale)
        {
            DSC_Time.ChangeUnityTimeScale(fTimeScale);
        }

        #endregion
    }
}