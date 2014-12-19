using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Q_Bank.View;
using Q_Bank.Model;

namespace Q_Bank.Controller
{
    public class MailingListController
    {
        private View.TabMailingList tss;


        public MailingListController(View.TabMailingList tss)
        {
            this.tss = tss;
        }


        public void SelectAllHandler(object sender, System.EventArgs e)
        {
            if (!tss.allesGeselecteerd)
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = true;
                }
                tss.allesGeselecteerd = true;
            }
            else
            {
                foreach (CheckBox item in tss.kies)
                {
                    item.Checked = false;
                }
                tss.allesGeselecteerd = false;
                tss.formMain.transactieStatusVerzenden.Enabled = false;
                tss.formMain.transactionStatusButtonAnnuleren.Enabled = false;
            }
        }

        public void Annuleren(object sender, EventArgs e)
        {
            var selectedId = from id in tss.kies
                             where id.Checked == true
                             select id.Tag;

            DialogResult result = MessageBox.Show("Wilt u de geselecteerde items annuleren?", "Weet u het zeker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                foreach (int id in selectedId)
                {
                    TransactionController.transactions.RemoveAt(id);
                }
                tss.FillList();
                MessageBox.Show("Alles is geannuuleerd", "annuleren");
            }
            else
            {
                MessageBox.Show("De annulerening is geannuleerd", "annuleren");
            }
        }

        public void Verzenden(object sender, EventArgs e)
        {
            var selectedId = from id in tss.kies
                             where id.Checked == true
                             select id.Tag;
            DialogResult result = MessageBox.Show("Wilt u de geselecteerde items verzenden?", "Weet u het zeker", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                foreach (int id in selectedId)
                {
                    using (var con = new Q_BANKEntities())
                    {
                        Transaction tp = TransactionController.transactions[id];
                        transactionqueue newTransaction = new transactionqueue()
                        {

                            transactionStatusId = 2,
                            accountId = tp.accountId,
                            amount = Convert.ToDouble(tp.amount),
                            datetime = DateTime.Now,
                            executeDate = Convert.ToDateTime(tp.executeDate),
                            ibanReceiver = tp.ibanReceiver,
                            nameReceiver = tp.nameReceiver,
                            sepa = Convert.ToInt16(tp.sepa),
                            bic = tp.bic,
                            remark = tp.remark
                        };
                        con.transactionqueues.Add(newTransaction);
                        con.SaveChanges();
                    }
                    TransactionController.transactions.RemoveAt(id);

                }
                tss.FillList();
                MessageBox.Show("Alle geselecteerde items zijn succesvol verzonden", "verzenden");
            }

            else
            {
                MessageBox.Show("De verzending is geannuleerd", "Verzenden");
            }
        }



        public void Refresch(object sender, EventArgs e)
        {
            tss.FillList();
        }

        public void CheckChanged(object sender, EventArgs e)
        {
            var selectedId = from id in tss.kies
                             where id.Checked == true
                             select id.Tag;

            if (selectedId.Count() > 0)
            {
                tss.formMain.transactieStatusVerzenden.Enabled = true;
                tss.formMain.transactionStatusButtonAnnuleren.Enabled = true;
            }
            else
            {
                tss.formMain.transactieStatusVerzenden.Enabled = false;
                tss.formMain.transactionStatusButtonAnnuleren.Enabled = false;
            }
        }
    }
}
