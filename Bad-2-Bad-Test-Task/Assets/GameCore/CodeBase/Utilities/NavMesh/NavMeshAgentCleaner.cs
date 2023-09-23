using UnityEngine;
using UnityEngine.AI;

namespace GameCore.CodeBase.Utilities.NavMesh
{
    public class NavMeshAgentCleaner : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private void Awake()
        {
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }
    }
}