using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TescoSWTestApp.Models;
using TescoSWTestApp.Views;
using Xamarin.Forms;

namespace TescoSWTestApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public ItemDetailViewModel()
        {
            EditCommand = new Command(OnEdit);
            DeleteCommand = new Command(OnDelete);
        }

        private string itemId;
        private string text;
        private string description;
        public Command EditCommand { get; }
        public Command DeleteCommand { get; }
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditItemPage)}?{nameof(EditItemViewModel.ItemId)}={Id}");
            Console.WriteLine("ItemId: "+ItemId);
        }
        private async void OnDelete()
        {
            Console.WriteLine("OnDelete");
            await DataStore.DeleteItemAsync(ItemId);
            await Shell.Current.GoToAsync("..");
        }
    }
}
