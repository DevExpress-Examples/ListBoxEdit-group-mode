﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations

Namespace DXGridSample
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
    <POCOViewModel> _
    Public Class MainViewModel
        Public Overridable Property Items() As ObservableCollection(Of Item)
        Public Overridable Property GroupedItems() As ICollectionView
        Public Sub New()
            Items = New ObservableCollection(Of Item)()
            For i As Integer = 0 To 99
                Items.Add(New Item With { _
                    .Id = i, _
                    .Name = "Name" & i, _
                    .GroupName = "Group" & i Mod 10 _
                })
            Next i
            Dim listCollectionView = New ListCollectionView(Items)
            listCollectionView.GroupDescriptions.Add(New PropertyGroupDescription("GroupName"))
            GroupedItems = listCollectionView
        End Sub
    End Class
    Public Class Item
        Public Property Id() As Integer
        Public Property Name() As String
        Public Property GroupName() As String

        Public Property grouping() As String
        Public Property SortIndex() As Integer
    End Class
    Public Class TestConverter
        Inherits MarkupExtension
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
            Return value
        End Function
        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
        Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
            Return Me
        End Function
    End Class
End Namespace