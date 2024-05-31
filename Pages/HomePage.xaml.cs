using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitStoreApp.ViewModels;

namespace FruitStoreApp.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel _viewModel;

    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }

    private void ProductsListControl_AddRemoveCartClicked(object sender, Controls.ProductCartItemChangeEventArgs e)
    {
        if (e.Count > 0)
        {
            _viewModel.AddToCartCommand.Execute(e.ProductId);
        }
        else
        {
            _viewModel.RemoveFromCartCommand.Execute(e.ProductId);
        }
    }
}