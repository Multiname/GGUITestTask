using System;
using MVP.Models;
using Zenject;

namespace MVP.Presenters
{
    public abstract class ListPresenterBase<T> : IDisposable, IInitializable
    {
        protected readonly ListModel<T> Model;

        protected ListPresenterBase(ListModel<T> model)
        {
            Model = model;
        }
        
        public void Initialize()
        {
            LoadList();
            Model.OnChanged += LoadList;
        }
        
        public void Dispose()
        {
            Model.OnChanged -= LoadList;
        }

        protected abstract void LoadList();
    }
}