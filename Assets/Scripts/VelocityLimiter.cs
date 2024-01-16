using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour
{
    [SerializeField] private bool LimitVelocity, LimitAngularVelocity;
    [SerializeField] private float MaxVelocity, MaxAngularVelocity;

    private ConfigurableJoint m_ConfigurableJoint;

    private void Awake()
    {
        m_ConfigurableJoint = GetComponent<ConfigurableJoint>();
    }

    private void Update()
    {
        if (LimitVelocity)
        {
            if (m_ConfigurableJoint.targetVelocity.magnitude > MaxVelocity)
            {
                m_ConfigurableJoint.targetVelocity = m_ConfigurableJoint.targetVelocity.normalized * MaxVelocity;
            }
        }

        if (LimitAngularVelocity)
        {
            if (m_ConfigurableJoint.targetAngularVelocity.magnitude > MaxAngularVelocity)
            {
                m_ConfigurableJoint.targetAngularVelocity = m_ConfigurableJoint.targetAngularVelocity.normalized * MaxAngularVelocity;
            }
        }
    }
}
