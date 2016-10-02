using Forms.Utils;
using Models;
using Repositories;
using Repositories.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmAdd : Form
    {
        public TypeAction TypeAction { get; private set; }        
        public RepositoryItensImplementation RepositoryItens { get; private set; }
        public int? Id { get; private set; }

        public FrmAdd(RepositoryItensImplementation repositoryItens, TypeAction typeAction = TypeAction.Add, int? id = null)
        {
            InitializeComponent();

            RepositoryItens = repositoryItens;

            TypeAction = typeAction;

            Id = id;
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            if (Id.HasValue)
            {
                Itens item = RepositoryItens.Find(Id.Value);
                TxtNome.Text = item.Nome;
                item = null;                
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                Itens item = null;
                if (TypeAction == TypeAction.Add)
                {
                    item = new Itens();
                    item.Nome = TxtNome.Text;
                    item.Teste = "t";
                    RepositoryItens.Add(item);
                }
                else if (TypeAction == TypeAction.Edit)
                {
                    item = RepositoryItens.Find(Id.Value);
                    item.Nome = TxtNome.Text;
                    RepositoryItens.Edit(item);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Erros", "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNome_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNome.Text))
            {
                errorProvider1.SetError(TxtNome, "Digite o texto");
                e.Lock();
            }
            else if (TxtNome.Text.Length < 3)
            {
                errorProvider1.SetError(TxtNome, "Digite o texto com mais de 3 letras");
                e.Lock();
            }
            else
            {
                errorProvider1.Clear();
                e.Free();
            }
        }
    }
}
