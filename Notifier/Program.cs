using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Classes;
using Common.Interfaces;
using Common.Models;
using System.Windows.Forms;

namespace Notifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"c://Notifier";
            string fileName = @"data.xml";
            DateTime triggerDate = DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["TriggerDateTime"]);

            var xM = new XmlMiddleware<NotiferModel>(filePath, fileName, "root");

            var readData = (NotiferModel)xM.Read();
            NotiferModel currentModel = readData == null ? new NotiferModel() : readData;
            DateTime curExpiration = DateTime.Parse(currentModel.Expiration);

            if (curExpiration < triggerDate)
            {
                MessageBox.Show(currentModel.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NotiferModel newModel = currentModel;
                newModel.Expiration = DateTime.Now.AddDays(1).ToShortDateString();
                xM.Write(newModel);
            }
        }
    }
}
