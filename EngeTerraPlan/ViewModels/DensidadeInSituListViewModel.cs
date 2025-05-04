using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EngeTerraPlan.Data;
using EngeTerraPlan.Models;
using EngeTerraPlan.Views;

namespace EngeTerraPlan.ViewModels
{
    public class DensidadeInSituListViewModel : BaseViewModel
    {
        public ObservableCollection<DensidadeInSituModel> DensidadeItems { get; set; }
        public ICommand LoadItemsCommand { get; }
        public ICommand CreateDensidadeCommand { get; }
        public ICommand RefreshItemsCommand { get; }

        private readonly IDispatcher _dispatcher;

        public DensidadeInSituListViewModel()
        {
            DensidadeItems = new ObservableCollection<DensidadeInSituModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            CreateDensidadeCommand = new Command(async () => await ExecuteCreateDensidadeCommand());
            RefreshItemsCommand = new Command(async () => await ExecuteRefreshItemsCommand());

            _dispatcher = Dispatcher.GetForCurrentThread() ?? throw new InvalidOperationException("Dispatcher não disponível.");
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                DensidadeItems.Clear();
                var items = await Task.Run(() => DatabaseService.Database.Table<DensidadeInSituModel>().ToList());
                foreach (var item in items)
                {
                    _dispatcher.Dispatch(() => DensidadeItems.Add(item));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar os itens: {ex.Message}");
            }
            finally
            {
                IsBusy = false; // Change IsBusy to false after loading items
            }
        }

        private async Task ExecuteCreateDensidadeCommand()
        {
            await Shell.Current.GoToAsync("///DensidadeInSituView");
        }

        private async Task ExecuteRefreshItemsCommand()
        {
            await ExecuteLoadItemsCommand();
        }
    }
}
