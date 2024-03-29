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
using System.Windows.Shapes;
using ModeloCliente;
using ModeloFuncionario;
using NegocioProgram;

namespace WpfApp1
{
    /// <summary>
    /// Lógica interna para AlterarConta.xaml
    /// </summary>
    public partial class AlterarConta : Window
    {
        public AlterarConta(string tA)
        {
            InitializeComponent();
            if (tA == "Funcionario")
            {
                funcionario.Visibility = Visibility.Hidden;
                administrador.Visibility = Visibility.Hidden;
            }
            TypeAccount.Text = tA;
        }
        NProgram p = new NProgram();
        private void Button_AlterarConta(object sender, RoutedEventArgs e)
        {
            foreach (MCliente c in p.ListarClientes()) if (c.Id == int.Parse(IdAccount.Text)) p.DeleteCliente(c);
            foreach (MFuncionario c in p.ListarFuncionario()) if (c.Id == int.Parse(IdAccount.Text)) p.DeleteFuncionario(c);
            if (cliente.IsChecked == true)
            {
                MCliente c = new MCliente(nomeConta.Text, senhaConta.Text, emailConta.Text);
                p.InserirCliente(c);
                c.SetId(int.Parse(IdAccount.Text));
                p.UpdateCliente(c);
                MessageBox.Show("Alterado com sucesso!");
                this.Close();
            }
            else if (funcionario.IsChecked == true)
            {
                MFuncionario c = new MFuncionario(nomeConta.Text, senhaConta.Text, emailConta.Text, false);
                p.InserirFuncionario(c);
                c.SetId(int.Parse(IdAccount.Text));
                p.UpdateFuncionario(c);
                MessageBox.Show("Alterado com sucesso!");
                this.Close();
            }
            else if (administrador.IsChecked == true)
            {
                MFuncionario c = new MFuncionario(nomeConta.Text, senhaConta.Text, emailConta.Text, true);
                p.InserirFuncionario(c);
                c.SetId(int.Parse(IdAccount.Text));
                p.UpdateFuncionario(c);
                MessageBox.Show("Alterado com sucesso!");
                this.Close();
            }
        }

        private void Button_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
