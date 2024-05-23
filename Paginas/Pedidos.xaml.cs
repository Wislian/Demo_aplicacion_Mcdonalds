using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace TimeTravel.Paginas
{
    public partial class Pedidos : ContentPage
    {
        private int pedidoCount = 0;
        private Random random = new Random();
        private Dictionary<string, string> comboPrices = new Dictionary<string, string>
        {
            { "Pollo con papas", "13000" },
            { "Hamburguesa con papas con gaseosa", "20000" },
            { "Hamburguesa con papas", "15000" }
        };
        private string[] combos = { "Pollo con papas", "Hamburguesa con papas con gaseosa", "Hamburguesa con papas" };
        private string[] epocas = { "1988-2000", "2000-2015", "2015-2024" };

        public Pedidos()
        {
            InitializeComponent();
        }

        private void OnPedidoCreatorClicked(object sender, EventArgs e)
        {
            pedidoCount++;
            string combo = combos[random.Next(combos.Length)];
            string valorPedido = comboPrices[combo];
            string epoca = epocas[random.Next(epocas.Length)];

            var pedidoGrid = new Grid
            {
                BackgroundColor = Colors.White,
                Margin = new Thickness(0, 10),
                Padding = new Thickness(10),
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            var pedidoInfoStack = new VerticalStackLayout
            {
                Spacing = 5
            };

            var pedidoNumberLabel = new Label
            {
                Text = $"Número del pedido: {pedidoCount}",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold
            };

            var valorPedidoLabel = new Label
            {
                Text = $"Valor del pedido: {valorPedido}",
                FontSize = 14
            };

            var comboLabel = new Label
            {
                Text = $"Combo: {combo}",
                FontSize = 14
            };

            var epocaLabel = new Label
            {
                Text = $"Época temática: {epoca}",
                FontSize = 12,
                TextColor = Colors.Gray
            };

            pedidoInfoStack.Children.Add(pedidoNumberLabel);
            pedidoInfoStack.Children.Add(valorPedidoLabel);
            pedidoInfoStack.Children.Add(comboLabel);
            pedidoInfoStack.Children.Add(epocaLabel);

            var pedidoIcon = new Image
            {
                Source = "feliz.png",
                HeightRequest = 50,
                WidthRequest = 50,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            pedidoGrid.Children.Add(pedidoInfoStack);
            Grid.SetColumn(pedidoInfoStack, 0);

            pedidoGrid.Children.Add(pedidoIcon);
            Grid.SetColumn(pedidoIcon, 1);

            PedidoList.Children.Add(pedidoGrid);
        }
    }
}
