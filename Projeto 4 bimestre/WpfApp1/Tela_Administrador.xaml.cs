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
using NegocioProgram;
using ModeloFuncionario;

namespace WpfApp1
{
    /// <summary>
    /// Lógica interna para Tela_Administrador.xaml
    /// </summary>
    public partial class Tela_Administrador : Window
    {
        public Tela_Administrador()
        {
            InitializeComponent();
        }
        NProgram p = new NProgram();
        private void Button_Sair(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void Button_Meus_Dados(object sender, RoutedEventArgs e)
        {
            Meus_Dados Md = new Meus_Dados();
            foreach (MFuncionario f in p.ListarFuncionario())
                if (f.Id == int.Parse(TypeAccount.Text))
                {
                    Md.TypeAccount.Text = "Administrador";
                    Md.IdAccount.Text = f.Id.ToString();
                    Md.nomeConta.Text = f.Nome.ToString();
                    Md.emailConta.Text = f.Email.ToString();
                    Md.senhaConta.Text = f.Senha.ToString();
                    Md.confSenha.Text = f.Senha.ToString();
                }
            Md.Show();
        }
    }
}
