using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;

namespace CustomTooltip {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            new DevExpress.XtraTreeList.Design.XViews(treeList1);
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e) {
            if(e.SelectedControl is DevExpress.XtraTreeList.TreeList) {
                TreeList tree = (TreeList)e.SelectedControl;
                TreeListHitInfo hit = tree.CalcHitInfo(e.ControlMousePosition);
                if(hit.HitInfoType == HitInfoType.Cell) {
                    object cellInfo = new TreeListCellToolTipInfo(hit.Node, hit.Column, null);
                    string toolTip = string.Format("{0} (Column: {1}, Node ID: {2})", hit.Node[hit.Column], hit.Column.FieldName, hit.Node.Id);
                    e.Info =  new DevExpress.Utils.ToolTipControlInfo(cellInfo, toolTip);                    
                }
            }
        }
    }
}