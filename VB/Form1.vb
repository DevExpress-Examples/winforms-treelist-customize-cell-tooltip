Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.ViewInfo

Namespace CustomTooltip

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim tmp_XViews = New Design.XViews(treeList1)
        End Sub

        Private Sub toolTipController1_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs)
            If TypeOf e.SelectedControl Is TreeList Then
                Dim tree As TreeList = CType(e.SelectedControl, TreeList)
                Dim hit As TreeListHitInfo = tree.CalcHitInfo(e.ControlMousePosition)
                If hit.HitInfoType = HitInfoType.Cell Then
                    Dim cellInfo As Object = New TreeListCellToolTipInfo(hit.Node, hit.Column, Nothing)
                    Dim toolTip As String = String.Format("{0} (Column: {1}, Node ID: {2})", hit.Node(hit.Column), hit.Column.FieldName, hit.Node.Id)
                    e.Info = New DevExpress.Utils.ToolTipControlInfo(cellInfo, toolTip)
                End If
            End If
        End Sub
    End Class
End Namespace
