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

        int Count
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


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                createNewModule.Click += new EventHandler(createNewModule_Click);
            //Displays on module by default
            for (int i = 1; i <= Count; i++)
            {
                LoadUserControl(i);
            }
        //}




    }


    protected void createNewModule_Click(object sender, EventArgs e)
        {
            Count++;
            LoadUserControl(Count);
        }

        void LoadUserControl(int index)
        {
            Control ctl = this.LoadControl("ModuleComponent.ascx");
            ctl.ID = string.Format("userControl_{0}", index);
            this.ModulePlaceholder.Controls.Add(ctl);
        }

        
    }
}