﻿#ExternalChecksum("..\..\Box.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","8A16C0A4FAC6E3B5F83BB0C57968C37B")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3615
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes


'''<summary>
'''Box
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class Box
    Inherits System.Windows.Controls.UserControl
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\Box.xaml",8)
    Friend WithEvents UserControl As Box
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Box.xaml",11)
    Friend WithEvents LayoutRoot As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Box.xaml",12)
    Friend WithEvents Radius As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Box.xaml",13)
    Friend WithEvents Cell As System.Windows.Controls.Border
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Box.xaml",14)
    Friend WithEvents Label As System.Windows.Controls.Label
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/Sudoku_Solver;component/box.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\Box.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.UserControl = CType(target,Box)
            Return
        End If
        If (connectionId = 2) Then
            Me.LayoutRoot = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 3) Then
            Me.Radius = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        If (connectionId = 4) Then
            Me.Cell = CType(target,System.Windows.Controls.Border)
            Return
        End If
        If (connectionId = 5) Then
            Me.Label = CType(target,System.Windows.Controls.Label)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class