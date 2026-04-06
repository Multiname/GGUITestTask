using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExternalSource
{
    public abstract class ListDataSourceBase<T> : ScriptableObject
    {
        public event Action<List<T>> OnChange;
        
        public virtual void ApplyChanges()
        {
            if (Application.isPlaying) OnChange?.Invoke(GetList());
        }
        
        public abstract List<T> GetList();
    }
}