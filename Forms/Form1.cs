using Forms.Utils;
using Repositories;
using Repositories.Interfaces;
using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {

        private IConnection Connection { get; set; }
        private RepositoryItensImplementation RepItens { get; set; }

        public Form1()
        {

            InitializeComponent();

            Connection = new Connection();
            RepItens = new RepositoryItens(Connection);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Call_Grid();
        }

        private void Call_Grid()
        {
            GridItens.DataSource = RepItens.ToList();
        }

        private void ButAdd_Click(object sender, EventArgs e)
        {
            using (FrmAdd frmAdd = new FrmAdd(RepItens, TypeAction.Add))
            {                
                frmAdd.ShowDialog();                
                Call_Grid();
            }
        }

        private void GridItens_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int? id = int.Parse(GridItens.Rows[e.RowIndex].Cells[0].Value.ToString());
                using (FrmAdd frmAdd = new FrmAdd(RepItens, TypeAction.Edit, id))
                {
                    frmAdd.ShowDialog();
                    Call_Grid();
                }
            }
        }
    }
}
