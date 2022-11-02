using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ChestConfigSO", menuName = "ScriptableObjects/Chests/ChestConfigurations")]
public class ChestConfigs : ScriptableObject
{
    [Serializable]
    public class ChestConfigPair
    {
        public ChestType ChestType;
        public ChestScriptableObject ChestSO;
    }

    public ChestConfigPair[] ChestConfigurationMap;
}
