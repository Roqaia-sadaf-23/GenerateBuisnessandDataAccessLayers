using GenerateBuisnessandDataAccessLayers.Buisness;
using GenerateBuisnessandDataAccessLayers.DataAccess;
using GenerateBuisnessandDataAccessLayers.Sitting;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GenerateBuisnessandDataAccessLayers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        void _fillDatabasesInCb()
        {
           // cbDatabase.Items.Clear();

            DataTable dataTable =clsGenarateData.GetDataBase();

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                cbDatabase.Items.Add(dataTable.Rows[i][0].ToString());
            }
            cbDatabase.SelectedIndex = 0;
        }

        void _filColumnsInCoboox()
        {

            cbFindBy.Items.Clear();
          

            DataTable dtColumn = clsGenarateData.GetColumn(cbTable.Text);

            foreach (DataRow row in dtColumn.Rows)
            {
                cbFindBy.Items.Add(row[0].ToString());
            }


            cbFindBy.SelectedIndex = 0;
        }


        void _fillTablesInCb()
        {

            cbTable.Items.Clear();
            DataTable dataTable = clsGenarateData.GetTable();

            foreach(DataRow row in dataTable.Rows)
            {
                cbTable.Items.Add(row[2].ToString());

            }

            cbTable.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _fillDatabasesInCb();
        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTable.Items.Clear();

            clsGeneratorSettungs.ConnectionString= @"Server=.;Database=" +cbDatabase.Text+";User Id=sa;Password=sa123456;";
            _fillTablesInCb();
            _filColumnsInCoboox();
        }

        private void btnListColumns_Click(object sender, EventArgs e)
        {
            dgvListColumns.DataSource = clsGenarateData.GetColumnProprety(cbTable.Text);
        }

        private void btnGenerateBuisness_Click(object sender, EventArgs e)
        {
            txtCodeScript.Text = "";

            txtCodeScript.Text = clsConstructor.GetConstructor(cbTable.Text,txtTableSingularName.Text,dgvListColumns.DataSource,cbFindBy.Text);
            txtCodeScript.Text += clsFind.FindFunc(cbTable.Text, txtTableSingularName.Text, dgvListColumns.DataSource, cbFindBy.Text);
            txtCodeScript.Text += clsAddNew.AddFunc(cbTable.Text, txtTableSingularName.Text, dgvListColumns.DataSource, cbFindBy.Text);
            txtCodeScript.Text += clsUpdate.updateFunc(cbTable.Text, txtTableSingularName.Text, dgvListColumns.DataSource, cbFindBy.Text);
            txtCodeScript.Text += clsSaveDeleteIsExistEvent.SaveFunc(txtTableSingularName.Text);
            txtCodeScript.Text += clsSaveDeleteIsExistEvent.DeleteFunc(txtTableSingularName.Text, cbFindBy.Text);
            txtCodeScript.Text += clsSaveDeleteIsExistEvent.GetAll(cbTable.Text, txtTableSingularName.Text);
            txtCodeScript.Text += clsSaveDeleteIsExistEvent.IsExitFunc(txtTableSingularName.Text, cbFindBy.Text, dgvListColumns.DataSource);

        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFindBy.Items.Clear();
            _filColumnsInCoboox();
        }

        private void btnGenerateDataAccess_Click(object sender, EventArgs e)
        {
            txtCodeScript.Text = clsFindData.FindFunc(cbTable.Text, txtTableSingularName.Text, dgvListColumns.DataSource, cbFindBy.Text);
            txtCodeScript.Text+= clsAddNewData.AddNewFunc(cbTable.Text, txtTableSingularName.Text, dgvListColumns.DataSource, cbFindBy.Text);
            txtCodeScript.Text += clsUpdateData.UpdateFunc(cbTable.Text, txtTableSingularName.Text, dgvListColumns.DataSource, cbFindBy.Text);
            txtCodeScript.Text += clsGetAllData.GetAllFunc(cbTable.Text);
            txtCodeScript.Text += clsIsExistData.IsExistFunc(cbTable.Text, txtTableSingularName.Text, dgvListColumns.DataSource, cbFindBy.Text);
            txtCodeScript.Text += clsDeleteData.DeleteFunc(cbTable.Text, txtTableSingularName.Text, dgvListColumns.DataSource, cbFindBy.Text);


            btnGenerateBuisness.Enabled = true;
        }
  
    
    
    }
}
