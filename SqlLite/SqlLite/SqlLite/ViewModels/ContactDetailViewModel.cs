﻿using SqlLite.Models;
using SqlLite.Repositories;
using SqlLite.Services;
using SqlLite.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

public class ContactsDetailViewModel
    {
        private readonly IContactRepository _contactStore;
        private readonly IPageService _pageService;

        public Contact Contact { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ContactsDetailViewModel(ContactViewModel viewModel, IContactRepository contactStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _contactStore = contactStore;

            SaveCommand = new Command(async () => await Save());

            Contact = new Contact
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
                IsFavorite = viewModel.IsFavorite,
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Contact.FirstName) && String.IsNullOrWhiteSpace(Contact.LastName))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (Contact.Id == 0)
            {
                await _contactStore.AddContact(Contact);
                MessagingCenter.Send(this, Events.ContactAdded, Contact);
            }
            else
            {
                await _contactStore.UpdateContact(Contact);
                MessagingCenter.Send(this, Events.ContactUpdated, Contact);
            }
            await _pageService.PopAsync();
        }
    }

namespace SqlLite.ViewModels
{
    public class ContactsDetailViewModel
    {
        private readonly IContactRepository _contactStore;
        private readonly IPageService _pageService;

        public Contact Contact { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ContactsDetailViewModel(ContactViewModel viewModel, IContactRepository contactStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _contactStore = contactStore;

            SaveCommand = new Command(async () => await Save());

            Contact = new Contact
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
                IsFavorite = viewModel.IsFavorite,
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Contact.FirstName) && String.IsNullOrWhiteSpace(Contact.LastName))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (Contact.Id == 0)
            {
                await _contactStore.AddContact(Contact);
                MessagingCenter.Send(this, Events.ContactAdded, Contact);
            }
            else
            {
                await _contactStore.UpdateContact(Contact);
                MessagingCenter.Send(this, Events.ContactUpdated, Contact);
            }
            await _pageService.PopAsync();
        }
    }
}
