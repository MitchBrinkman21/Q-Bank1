using Q_Bank;
using Q_Bank_Administration.View;
using System;
using System.Collections;
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
        private DeclineTerminate dt;
        List<CheckBox> checkBoxes = new List<CheckBox>();


        public TerminateAccountsController(FormMain formMain)
        {
            this.formMain = formMain;
            AddTableLayout();
            AddButton(formMain.tabPage5);
            AddDefaultLabels();
            FillTable();
            ResetTableLayout();
        }

        private void AddButton(TabPage tab)
        {
            Button Decline = new Button();
            Button Accept = new Button();
            Decline.Text = "Annuleren";
            Accept.Text = "Bevestigen";
            Decline.Size = new Size(121, 23);
            Accept.Size = new Size(121, 23);
            Decline.Location = new Point(838, 12);
            Accept.Location = new Point(700, 12);

            Decline.Click += DeclineButton;
            Accept.Click += AcceptButton;
            Decline.Visible = true;
            Accept.Visible = true;
            tab.Controls.Add(Decline);
            tab.Controls.Add(Accept);
        }

        private void DeclineButton(Object sender, EventArgs e)
        {
            var selectedCheckBoxes = from id in checkBoxes
                                     where id.Checked == true
                                     select id;
            if (selectedCheckBoxes.Count() > 0)
            {
                List<CheckBox> selectedCheckBoxesArray = new List<CheckBox>();
                foreach (CheckBox cb in selectedCheckBoxes)
                {
                    selectedCheckBoxesArray.Add(cb);
                }
                dt = new DeclineTerminate(selectedCheckBoxesArray);
                dt.ShowDialog();
                if (dt.CloseForm == true)
                {
                    foreach (CheckBox cb in selectedCheckBoxes)
                    {
                        int cb2 = Convert.ToInt32(cb.Tag.ToString());
                        using (var con = new Q_BANKEntities())
                        {
                            var beeindigen = from a in con.accounts
                                             where a.active == true && a.accountId == cb2
                                             select a;

                            foreach (account a in beeindigen)
                            {
                                a.deleteRequest = false;
                            }

                            try
                            {
                                con.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                            ResetTable();
                            AddDefaultLabels();
                            FillTable();
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("U heeft geen rekeningen geselecteerd om te beëindigen", "Rekening beëindigen",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void AcceptButton(Object sender, EventArgs e)
        {
                var selectedCheckBoxes = from id in checkBoxes
                                 where id.Checked == true
                                 select id;
                    if (selectedCheckBoxes.Count() > 0)
                    {
                        List<CheckBox> selectedCheckBoxesArray = new List<CheckBox>();
                        foreach (CheckBox cb in selectedCheckBoxes)
                        {
                            selectedCheckBoxesArray.Add(cb);
                        }
                        at = new AcceptTerminate(selectedCheckBoxesArray);
                        at.ShowDialog();
                        if (at.CloseForm == true)
                        {
                            foreach (CheckBox cb in selectedCheckBoxes)
                            {
                                int cb2 = Convert.ToInt32(cb.Tag.ToString());
                                using (var con = new Q_BANKEntities())
                                {
                                    var beeindigen = from a in con.accounts
                                                     where a.active == true && a.accountId == cb2
                                                     select a;

                                    foreach(account a in beeindigen)
                                    {
                                        a.active = false;
                                        a.deleteRequest = false;
                                    }

                                    try
                                    {
                                        con.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                    
                                }
                                                  
                            }
                            ResetTable();
                            AddDefaultLabels();
                            FillTable();
                        }
                    }
                    else
                    {
                        MessageBox.Show("U heeft geen rekeningen geselecteerd om te beëindigen", "Rekening beëindigen",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
        }

        private void ResetTable()
        {
            tableLayout.Controls.Clear();
            tableLayout.RowStyles.Clear();
            tableLayout.RowCount = 1;
        }

        private void AddTableLayout()
        {
            tableLayout = new TableLayoutPanel();
            tableLayout.SuspendLayout();
            formMain.tabPage5.Controls.Add(tableLayout);
            tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayout.AutoScroll = true;
            tableLayout.BackColor = System.Drawing.Color.Transparent;
            tableLayout.ColumnCount = 3;
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40));
            tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            tableLayout.Location = new System.Drawing.Point(10, 50);
            tableLayout.RowCount = 1;
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayout.Size = new System.Drawing.Size(970, 540);
            tableLayout.TabIndex = 0;
            
        }

        private void ResetTableLayout()
        {
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
        }

        private void AddDefaultLabels()
        {
            Label defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = "Rekening";
            defaultLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel, 0, 0);

            Label defaultLabel2 = new Label();
            defaultLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel2.Text = "Klantnummer";
            defaultLabel2.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel2, 1, 0);

            Label defaultLabel3 = new Label();
            defaultLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel3.Text = "Beëindigen";
            defaultLabel3.Font = new Font("Arial", 9, FontStyle.Bold);
            tableLayout.Controls.Add(defaultLabel3, 2, 0);
        }

        private void FillTable()
        {
            using (var con = new Q_BANKEntities())
            {
                var beeindigen = from a in con.accounts
                                 where a.deleteRequest == true
                                 select new { a.accountNumber, a.customerId, a.accountId };

                if (beeindigen.Count() > 0)
                {
                    int i = 1;
                    foreach (var a in beeindigen)
                    {
                        addItems(a.accountNumber, a.customerId, a.accountId, i);
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
            //verwijderd de verticale scrollbar
            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            tableLayout.Padding = new Padding(0, 0, vertScrollWidth, 0);
            //zorgt voor het uitlijnen van de table inhoud
            Label tempLabel = new Label();
            tableLayout.Controls.Add(tempLabel, 1, tableLayout.RowCount + 1);

        }

        private void addItems(string a, int b, int c, int position)
        {
            Label defaultLabel = new Label();
            defaultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel.Text = a;
            tableLayout.Controls.Add(defaultLabel, 0, position);

            Label defaultLabel2 = new Label();
            defaultLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            defaultLabel2.Text = b.ToString();
            tableLayout.Controls.Add(defaultLabel2, 1, position);

            CheckBox checkBox1 = new CheckBox();
            checkBox1.Tag = c;
            checkBoxes.Add(checkBox1);
            tableLayout.Controls.Add(checkBox1, 2, position);

            tableLayout.RowCount += 1;
        }
    }
}
