using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Classes;
using Middleware.Interfaces;
using Common;
using Common.Interfaces;
using Common.Models;
using System.Windows.Forms;

namespace Notifier
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime triggerDate = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["TriggerDateTime"]);

            IMiddleware<NotiferModel> xM = new XmlMiddleware<NotiferModel>(NotifierFileInfo.FilePath, NotifierFileInfo.FileName, NotifierFileInfo.RootNodeName);

            NotiferModel readData = xM.Read();
            NotiferModel currentModel = readData == null ? new NotiferModel() : readData;

            if (currentModel.GetExpirationDate() < triggerDate)
            {
                MessageBox.Show(currentModel.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NotiferModel newModel = currentModel;
                newModel.Expiration = DateTime.Now.AddDays(1).ToShortDateString();
                xM.Write(newModel);
            }
        }
    }
}
