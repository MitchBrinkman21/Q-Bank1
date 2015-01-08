using Q_Bank;
using Q_Bank_Administration.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Bank_Administration.Controller
{
    class TerminateAccountsController
    {
        public FormMain formMain { get; set; }
        private TableLayoutPanel tableLayout;
        private AcceptTerminate at;
        private CheckBox checkBox1;


        public TerminateAccountsController(FormMain formMain)
        {
            this.formMain = formMain;
            AddTableLayout();
            AddButton();
            AddDefaultLabels();
            FillTable();
        }

        private void AddButton()
        {
            Button Decline = new Button();
            Button Accept = new Button();
            Decline.Text = "Annuleren";
            Accept.Text = "Bevestigen";
            Decline.Size = new Size(121, 23);
            Accept.Size = new Size(121, 23);
            Decline.Location = new Point(10, 500);
            Accept.Location = new Point(800, 500);

            Decline.Click += DeclineButton;
            Accept.Click += AcceptButton;
            Decline.Visible = true;
            Accept.Visible = true;
        }

        private void DeclineButton(Object sender, EventArgs e)
        {
            
        }

        private void AcceptButton(Object sender, EventArgs e)
        {
            using (at = new AcceptTerminate())
            {
                if (checkBox1.Checked)
                {
                    at.ShowDialog();
                    if (at.CloseForm == true)
                    {

                    }
                }

                else
                {
                    MessageBox.Show("U heeft geen rekeningen geselecteerd om te beëindigen", "Rekening beëindigen",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddTableLayout()
        {
            tableLayout = new TableLayoutPanel();
            tableLayout.SuspendLayout();
            tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayout.AutoScroll = true;
            tableLayout.BackColor = System.Drawing.Color.Transparent;
            tableLayout.ColumnCount = 3;
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
        }

        private void AddDefaultLabels()
        {
            Label defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Rekening";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 0, 0);

            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Naam";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 1, 0);

            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Beëindigen";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 2, 0);
        }

        private void FillTable()
        {
            using (var con = new Q_BANKEntities())
            {
                var beeindigen = from a in con.accounts
                                 where a.deleteRequest == true
                                 select new { a.accountNumber, a.customerId };

                if (beeindigen.Count() > 0)
                {
                    int i = 1;
                    foreach (var a in beeindigen)
                    {
                        addItems(a.accountNumber, a.customerId, i);
                        i++;
                    }
                }

                else
                {
                    Label defaultLabel = new Label();
                    defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
                    defaultLabel.Text = "Er zijn geen verzoeken voor het beëindigen van een rekening gevonden.";
                    tableLayout.Controls.Add(defaultLabel, 1, 1);
                }
            }

        }

        private void addItems(string a, int b, int position)
        {
            Label defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = a;
            tableLayout.Controls.Add(defaultLabel, 0, position);

            defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = b.ToString();
            tableLayout.Controls.Add(defaultLabel, 1, position);

            checkBox1 = new CheckBox();
            tableLayout.Controls.Add(checkBox1, 2, position);
        }
    }
}
