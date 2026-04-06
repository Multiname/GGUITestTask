using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExternalSource.ListDataSources
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