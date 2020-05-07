using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TITLib;

namespace TIT
{
    public partial class statistic : System.Web.UI.Page
    {
        //Counting variable according to the ViewState
        public int Count
        {
            get
            {
                if (ViewState["ControlCount"] == null)
                    ViewState["ControlCount"] = 1;
                return (int)ViewState["ControlCount"];
            }
            set
            {
                ViewState["ControlCount"] = value;
            }
        }

        /// <summary>
        /// Gets triggered by every reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Does display one module by default
            for (int i = 1; i <= Count; i++)
            {
                LoadUserControl(i);
            }
        }

        /// <summary>
        /// Gets clicking on adding new module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void createNewModule_Click(object sender, EventArgs e)
        {
            Count++;
            LoadUserControl(Count);
        }
        /// <summary>
        /// Does load the controlls
        /// </summary>
        /// <param name="index"></param>
        void LoadUserControl(int index)
        {
            Control moduleCmpt = this.LoadControl("ModuleComponent.ascx");
            //moduleCmpt.ID = string.Format("userControl_{0}", index);
            moduleCmpt.ID = string.Format("{0}", index);

            this.ModulePlaceholder.Controls.Add(moduleCmpt);
        }

        protected void deleteAllModules_Click(object sender, EventArgs e)
        {
            ModulePlaceholder.Controls.Clear();
        }
    }
}