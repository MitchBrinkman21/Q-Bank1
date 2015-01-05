using Q_Bank;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                FillTable(0);
                break;
                case 1:
                AddTableLayout(formMain.tabPage8);
                AddDefaultLabels();
                FillTable(1);
                break;
                case 2:
                AddTableLayout(formMain.tabPage9);
                AddDefaultLabels();
                FillTable(2);
                break;
                default:
                AddTableLayout(formMain.tabPage7);
                AddDefaultLabels();
                FillTable(0);
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
            tableLayout.ColumnCount = 7;
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            tableLayout.Location = new System.Drawing.Point(10, 50);
            tableLayout.RowCount = 1;
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayout.Size = new System.Drawing.Size(970, 540);
            tableLayout.TabIndex = 0;
            //tableLayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            

            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
        }

        private void AddDefaultLabels()
        {
            Label defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Gebruikersnaam";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 0, 0);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Voornaam";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 1, 0);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Achternaam";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 2, 0);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Adres";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 3, 0);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Woonplaats";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 4, 0);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "BSN";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 5, 0);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Status";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 6, 0);
        }

        private void FillTable(int tabID)
        {
            using (var con = new Q_BANKEntities())
            {
                var gebruikers = from g in con.customers
                                 select g;
                if (gebruikers.Count() > 0)
                {
                    if (tabID == 0)
                    {
                        int i = 1;
                        foreach (customer c in gebruikers)
                        {
                            AddItems(c, i);
                            i++;
                        }
                    }
                    else if (tabID == 1)
                    {
                        var active = from a in gebruikers
                                     where a.active == true
                                     select a;

                        int i = 1;
                        foreach (customer c in active)
                        {
                            AddItems(c, i);
                            i++;
                        }
                    }
                    else if (tabID == 2)
                    {
                        var notActive = from a in gebruikers
                                        where a.active == false
                                        select a;

                        int i = 1;
                        foreach (customer c in notActive)
                        {
                            AddItems(c, i);
                            i++;
                        }
                    }
                }
                else
                {
                    Label defaultLabel = new Label();
                    defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                    defaultLabel.Text = "Er zijn geen gebruikers gevonden";
                    tableLayout.Controls.Add(defaultLabel, 1, 1);
                }
            }
            
            
            //verwijderd de verticale scrollbar
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            tableLayout.Padding = new Padding(0, 0, vertScrollWidth, 0);

            Label tempLabel = new Label();
            tableLayout.Controls.Add(tempLabel, 1, tableLayout.RowCount + 1);
        }

        private void AddItems(customer gebruiker, int position)
        {
            Label defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = gebruiker.username;
            defaultLabel.Tag = gebruiker.customerId;
            defaultLabel.Click += LabelClick; 
            tableLayout.Controls.Add(defaultLabel, 0, position);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = gebruiker.firstName;
            defaultLabel.Tag = gebruiker.customerId;
            defaultLabel.Click += LabelClick; 
            tableLayout.Controls.Add(defaultLabel, 1, position);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = gebruiker.lastName;
            defaultLabel.Tag = gebruiker.customerId;
            defaultLabel.Click += LabelClick; 
            tableLayout.Controls.Add(defaultLabel, 2, position);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Adress";
            defaultLabel.Tag = gebruiker.customerId;
            defaultLabel.Click += LabelClick; 
            tableLayout.Controls.Add(defaultLabel, 3, position);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Woonplaats";
            defaultLabel.Tag = gebruiker.customerId;
            defaultLabel.Click += LabelClick; 
            tableLayout.Controls.Add(defaultLabel, 4, position);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = gebruiker.bsn.ToString();
            defaultLabel.Tag = gebruiker.customerId;
            defaultLabel.Click += LabelClick; 
            tableLayout.Controls.Add(defaultLabel, 5, position);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            if (gebruiker.active == true) 
            {
                defaultLabel.Text = "actief";
            }
            else
            {
                defaultLabel.Text = "in actief";
            }
            defaultLabel.Tag = gebruiker.customerId;
            defaultLabel.Click += LabelClick; 
            tableLayout.Controls.Add(defaultLabel, 6, position);

            tableLayout.RowCount += 1;
        }

        private void LabelClick(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                MessageBox.Show(clickedLabel.Tag.ToString(), "customer ID");
            }
        }
    }
}
