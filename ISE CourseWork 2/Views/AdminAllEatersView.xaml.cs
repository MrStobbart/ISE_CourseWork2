﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ISE_CourseWork_2.Models;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for AdminAllEatersView.xaml
    /// </summary>
    public partial class AdminAllEatersView : Page
    {
        private List<Eater> Eaters { get; set; }
        private List<AdminEaterRow> TableData { get; set; }

        public AdminAllEatersView()
        {
            InitializeComponent();

            TableData = new List<AdminEaterRow>();

            CreateTableMealShares();
        }

        public void CreateTableMealShares()
        {
            // Sort meal shares according to date
            Eaters = ((MainWindow)App.Current.MainWindow).RuntimeDb.Eaters.OrderBy(Eater => Eater.FirstName).ToList();

            foreach (Eater Eater in Eaters)
            {
                AdminEaterRow AdminEaterRow = new AdminEaterRow(Eater.Id);
                AdminEaterRow.Name = Eater.GetFullName();
                AdminEaterRow.StreetAndNumber = Eater.Address.Street + " " + Eater.Address.HouseNumber;
                AdminEaterRow.ZipCode = Eater.Address.ZipCode;
                AdminEaterRow.City = Eater.Address.City;
                AdminEaterRow.PhoneNumber = Eater.PhoneNumber;

                List<Feedback> Feedbacks = ((MainWindow)App.Current.MainWindow).RuntimeDb.Feedbacks;
                int SumRating = 0;
                int RatingCount = 0;
                foreach (Feedback Feedback in Feedbacks)
                {
                    if (Feedback.Type == FeedbackType.MealShare)
                    {
                        MealShare MealShare = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindMealShare(Feedback.MealShareId);
                        if (MealShare.EaterId == Eater.Id)
                        {
                            SumRating += Feedback.Rating;
                            RatingCount++;
                        }
                    }
                }
                if(RatingCount == 0)
                {
                    AdminEaterRow.AverageRating = "-";
                }
                else
                {
                    AdminEaterRow.AverageRating = Math.Round(((double)SumRating / (double)RatingCount), 1).ToString();
                }

                TableData.Add(AdminEaterRow);
            }

            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(TryFindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = TableData;
        }

    }

    class AdminEaterRow
    {
        public string Name { get; set; }

        public string StreetAndNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string AverageRating { get; set; }

        public string Id { get; set; }

        public AdminEaterRow(string Id)
        {
            this.Id = Id;
        }
    }

}
