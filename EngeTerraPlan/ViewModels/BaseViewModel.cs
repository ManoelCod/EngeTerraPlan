using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EngeTerraPlan.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        // Evento para notificar mudanças de propriedades
        public event PropertyChangedEventHandler PropertyChanged;

        // Método auxiliar para disparar notificações de mudança
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Método genérico para atualizar propriedades e disparar notificação
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        // Propriedade para indicar se o ViewModel está em carregamento
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        // Propriedade para título da página, caso necessário
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
