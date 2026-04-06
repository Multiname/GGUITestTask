using System;
using MVP.Models.ListModels;
using Zenject;

namespace MVP.Presenters.ListPresenters
{
    public abstract class ListPresenterBase<T> : IDisposable, IInitializable
    {
        protected readonly ListModel<T> Model;

        protected ListPresenterBase(ListModel<T> model)
        {
            Model = model;
        }
        
        public virtual void Initialize()
        {
            LoadList();
            Model.OnChanged += LoadList;
        }
        
        public virtual void Dispose()
        {
            Model.OnChanged -= LoadList;
        }

        protected abstract void LoadList();
    }
}