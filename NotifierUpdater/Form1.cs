using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Models;
using Middleware.Classes;

namespace NotifierUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var xM = new XmlMiddleware<NotiferModel>(NotifierFileInfo.FilePath, NotifierFileInfo.FileName, NotifierFileInfo.RootNodeName);
            NotiferModel currentModel = xM.Read();

            dtpExpiration.Value = currentModel.GetExpirationDate();
            tbxMessage.Text = currentModel.Message;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NotiferModel model = new NotiferModel()
                {
                    Expiration = dtpExpiration.Value.ToShortDateString(),
                    Message = tbxMessage.Text
                };

                var xM = new XmlMiddleware<NotiferModel>(NotifierFileInfo.FilePath, NotifierFileInfo.FileName, NotifierFileInfo.RootNodeName);
                xM.Write(model);
                lblError.Visible = false;
            }
            catch
            {
                lblError.Text = "Error has occured";
                lblError.Visible = true;
            }
        }
    }
}
