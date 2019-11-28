using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace CombinedElementsLesson
{
    /// <summary>
    /// Interaction logic for TraderTable.xaml
    /// </summary>
    public partial class TraderTable : UserControl
    {
        private List<Company> companies;

        public TraderTable()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            using(var context = new TraderContext())
            {
                companies = context.GetCompanies.ToList();
                priceHistoryDG.ItemsSource = context.GetPriceHistories.Where(X => X.CompanyId == companies.FirstOrDefault().Id).ToList();
                companiesCB.ItemsSource = companies;
            }
        }

        private void UpdateClicked(object sender, RoutedEventArgs e)
        {
            var index = companiesCB.SelectedIndex;
            using(var context = new TraderContext())
            {
                priceHistoryDG.ItemsSource = context.GetPriceHistories.Where(X => X.CompanyId == companies[index].Id).ToList();
            }
        }
    }
}
