using System;
using System.Collections.Generic;
using System.Linq;
using ExternalSource.ListDataSources;
using Zenject;

namespace MVP.Models.ListModels
{
    public class ListModel<T> : IDisposable, IInitializable
    {
        private readonly ListDataSourceBase<T> _dataSource;
        
        protected List<T> List;

        public event Action OnChanged;

        [Inject]
        public ListModel(ListDataSourceBase<T> dataSource)
        {
            _dataSource = dataSource;
        }
        
        public void Initialize()
        {
            List = _dataSource.GetList();
            _dataSource.OnChange += SetList;
        }
        
        public void Dispose()
        {
            _dataSource.OnChange -= SetList;
        }

        public List<T> GetList() => List.ToList();
        
        private void SetList(List<T> list)
        {
            List = list;
            InvokeOnChanged();
        }
        
        protected void InvokeOnChanged() => OnChanged?.Invoke();
    }
}