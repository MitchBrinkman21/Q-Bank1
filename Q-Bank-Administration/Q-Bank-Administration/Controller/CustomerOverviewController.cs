using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank_Administration.Controller
{
    class CustomerOverviewController
    {
        public FormMain formMain { get; set; }
        private TableLayoutPanel tableLayout;
        public CustomerOverviewController(FormMain formMain)
        {
            this.formMain = formMain;
            formMain.tabControl2.SelectedIndexChanged += TabControl;


            TabControl(null, null);
        }

        private void TabControl(object sender, EventArgs e)
        {
            switch (formMain.tabControl2.SelectedIndex)
            {
                case 0:
                    AddTableLayout(formMain.tabPage7);
                    AddDefaultLabels();
                    break;
                case 1:
                    AddTableLayout(formMain.tabPage8);
                    AddDefaultLabels();
                    break;
                case 2:
                    AddTableLayout(formMain.tabPage9);
                    AddDefaultLabels();
                    break;
                default:
                    AddTableLayout(formMain.tabPage7);
                    AddDefaultLabels();
                    break;
            }
        }

        private void AddTableLayout(TabPage tab)
        {
            tableLayout = new TableLayoutPanel();
            tableLayout.SuspendLayout();
            tab.Controls.Add(tableLayout);
            tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayout.AutoScroll = true;
            tableLayout.BackColor = System.Drawing.Color.Transparent;
            tableLayout.ColumnCount = 6;
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayout.Location = new System.Drawing.Point(10, 10);
            tableLayout.RowCount = 2;
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayout.Size = new System.Drawing.Size(918, 492);
            tableLayout.TabIndex = 0;

            //verwijderd de verticale scrollbar
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            tableLayout.Padding = new Padding(0, 0, vertScrollWidth, 0);

            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
        }

        private void AddDefaultLabels()
        {
            Label defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Gebruikersnaam";
            tableLayout.Controls.Add(defaultLabel, 0, 0);

            Label defaultLabel1 = new Label();
            defaultLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel1.Text = "Voornaam";
            tableLayout.Controls.Add(defaultLabel1, 1, 0);

            Label defaultLabel2 = new Label();
            defaultLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel2.Text = "Achternaam";
            tableLayout.Controls.Add(defaultLabel2, 2, 0);

            Label defaultLabel3 = new Label();
            defaultLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel3.Text = "Adres";
            tableLayout.Controls.Add(defaultLabel3, 3, 0);

            Label defaultLabel4 = new Label();
            defaultLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel4.Text = "Woonplaats";
            tableLayout.Controls.Add(defaultLabel4, 4, 0);

            Label defaultLabel5 = new Label();
            defaultLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel5.Text = "BSN";
            tableLayout.Controls.Add(defaultLabel5, 5, 0);
            //defaultLabel.Text = "Status";
            //tableLayout.Controls.Add(defaultLabel, 6, 0);
        }

        private void FillTable()
        {
            switch (formMain.tabControl2.SelectedIndex)
            {
                case 0:
                
                    break;
                case 1:
                
                    break;
                case 2:
                
                    break;
                default:
                
                    break;
            }
        }
    }
}
