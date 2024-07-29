using System;
using UnityEngine;

namespace _Project.Common.Ui
{
    [Serializable]
    public class TeamColor
    {
        [field:SerializeField] public int Team;
        [field:SerializeField] public Color Color;
    }
}