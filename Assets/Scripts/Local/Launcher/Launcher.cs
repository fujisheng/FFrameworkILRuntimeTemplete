using Framework.Module;
using Framework.Module.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Launch
{
    public class Launcher : MonoBehaviour
    {
        private void Awake()
        {
            var fsmManager = ModuleManager.Instance.GetModule<IFSMManager>();
            var fsm = fsmManager.CreateFSM<Launcher>(this, new LoadModuleState());
            fsm.Start<LoadModuleState>();
            DontDestroyOnLoad(gameObject);
        }
    }
}