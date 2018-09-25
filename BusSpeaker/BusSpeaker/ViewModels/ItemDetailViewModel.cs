using System;

using BusSpeaker.Models;

namespace BusSpeaker.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Rout Item { get; set; }
        public ItemDetailViewModel(Rout item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
