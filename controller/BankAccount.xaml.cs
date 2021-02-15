﻿using MoneyManagerToUniversity.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace MoneyManagerToUniversity.controller
{
    /// <summary>
    /// Logika interakcji dla klasy BankAccount.xaml
    /// </summary>
    public partial class BankAccount : Window
    {
        MoneyManagerEntities context = new MoneyManagerEntities();
        CollectionViewSource bankSource;
        CollectionViewSource bankAccountSource;

        public BankAccount()
        {
            InitializeComponent();

            bankSource = ((CollectionViewSource)(FindResource("bankViewSource")));
            bankAccountSource = ((CollectionViewSource)(FindResource("bank_accountViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            context.bank.Load();
            context.bank_account.Load();

            bankSource.Source = context.bank.Local;
            bankAccountSource.Source = context.bank_account.Local;
        }

        private void CreateAndSaveBanksCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            bank bank;

            bank = new bank
            {
                name = bankName.Text,
            };

            context.bank.Local.Insert(context.bank.Local.Count(), bank);

            bankSource.View.Refresh();
            bankSource.View.MoveCurrentTo(bank);

            context.SaveChanges();
        }

        private void SaveBanksCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void CreateAndSaveBanksAccountCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            bank_account bank_account;


            int bankId;
            decimal currentBallance;

            try
            {
                bankId = int.Parse(bank_idTextBox.Text);
                currentBallance = decimal.Parse(current_ballanceTextBox.Text);
            } catch(Exception)
            {
                MessageBox.Show("Giva bad data, expceted int and decimal");
                return;
            }

            bank_account = new bank_account
            {
                bank_id = bankId,
                name = nameTextBox.Text,
                current_ballance = currentBallance,
                //TODO: validate and unit test
                number = numberTextBox.Text,
                created_at = DateTime.Now,
            };

            context.bank_account.Local.Insert(context.bank_account.Local.Count(), bank_account);

            bankSource.View.Refresh();
            bankSource.View.MoveCurrentTo(bank_account);

            try
            {
                context.SaveChanges();
            } catch(Exception)
            {
                MessageBox.Show("Give bad relationships ID");
            }
        }

        private void SaveBanksAccountCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Give bad relationships ID");
            }
        }

        private void DeleteBankAccountCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show(bankAccountIdToDelete.Text);
        }
    }
}
