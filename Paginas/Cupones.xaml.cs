using Microsoft.Maui.Controls;
using System;
using System.Text;

namespace TimeTravel.Paginas
{
    public partial class Cupones : ContentPage
    {
        private int cuponCount = 0;

        public Cupones()
        {
            InitializeComponent();
        }

        private void OnCuponCreatorClicked(object sender, EventArgs e)
        {
            cuponCount++;
            string newCuponCode = GenerateRandomCuponCode();
            var validUntil = DateTime.Now.AddMonths(1).ToString("dd MMM yyyy");

            var cuponGrid = new Grid
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

            var cuponInfoStack = new VerticalStackLayout
            {
                Spacing = 5
            };

            var cuponNumberLabel = new Label
            {
                Text = $"Cupon {cuponCount}",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold
            };

            var cuponCodeLabel = new Label
            {
                Text = newCuponCode,
                FontSize = 14
            };

            var validUntilLabel = new Label
            {
                Text = $"Válido hasta: {validUntil}",
                FontSize = 12,
                TextColor = Colors.Gray
            };

            cuponInfoStack.Children.Add(cuponNumberLabel);
            cuponInfoStack.Children.Add(cuponCodeLabel);
            cuponInfoStack.Children.Add(validUntilLabel);

            var cuponIcon = new Image
            {
                Source = "icon_m.png",
                HeightRequest = 50,
                WidthRequest = 50,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            cuponGrid.Children.Add(cuponInfoStack);
            Grid.SetColumn(cuponInfoStack, 0);

            cuponGrid.Children.Add(cuponIcon);
            Grid.SetColumn(cuponIcon, 1);

            CuponList.Children.Add(cuponGrid);
        }

        private string GenerateRandomCuponCode()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder cuponCode = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cuponCode.Append(chars[random.Next(chars.Length)]);
                }
                if (i < 2)
                {
                    cuponCode.Append('-');
                }
            }

            return cuponCode.ToString();
        }
    }
}
