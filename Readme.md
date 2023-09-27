<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128637428/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E580)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms TreeList - Customize cell tooltips (hints)

This example shows how to handle the [ToolTipController.GetActiveObjectInfo](https://docs.devexpress.com/WindowsForms/DevExpress.Utils.ToolTipController.GetActiveObjectInfo) event to customize the tooltips displayed for TreeList cells:

```csharp
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
```


## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Hints and Tooltips](https://docs.devexpress.com/WindowsForms/2398/common-features/tooltips)


## See Also

* [WinForms Data Grid - How to display tooltips for grid cells if cell content is completely visible](https://supportcenter.devexpress.com/ticket/details/e714/winforms-data-grid-how-to-display-tooltips-for-grid-cells-if-cell-content-is-completely)
* [How to get multi-line tooltips with a specific width](https://supportcenter.devexpress.com/ticket/details/a384/how-to-get-multi-line-tooltips-with-a-specific-width)
* [How to programmatically display a tooltip for a control via the ToolTipController component](https://supportcenter.devexpress.com/ticket/details/a555/how-to-programmatically-display-a-tooltip-for-a-control-via-the-tooltipcontroller)
* [How to display a hint for an active editor within the XtraGrid](https://supportcenter.devexpress.com/ticket/details/a2008/how-to-display-a-hint-for-an-active-editor-within-the-xtragrid)
* [How to display hints only for particular cells](https://supportcenter.devexpress.com/ticket/details/a2566/how-to-display-hints-only-for-particular-cells)
