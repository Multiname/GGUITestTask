using System;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class Achievement
    {
        public int iconId;
        [NonSerialized] public Sprite Icon = null;
        public string header;
        public Date date;
        
        [Serializable]
        public struct Date
        {
            public int day, month, year;
        }
    }
}