using System.Collections.Generic;
using UnityEngine;

namespace CustomUpdateManager
{
    public static class UpdateManager
    {
        private static UpdateManagerInnerMonoBehaviour innerMonoBehaviour;
        private static HashSet<ManagedMover> updateHashes = new HashSet<ManagedMover>();

        static UpdateManager()
        {
            var gameObject = new GameObject();
            innerMonoBehaviour = gameObject.AddComponent<UpdateManagerInnerMonoBehaviour>();
        }

        public static void Add(ManagedMover mover)
        {
            updateHashes.Add(mover);
        }

        public static void Remove(ManagedMover mover)
        {
            updateHashes.Remove(mover);
        }

        class UpdateManagerInnerMonoBehaviour : MonoBehaviour
        {
            private void Update()
            {
                foreach(var mover in updateHashes)
                {
                    mover.UpdateManager_Update();
                }
            }
        }
    }
}
